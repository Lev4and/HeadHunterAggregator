using FluentValidation;
using HeadHunterAggregator.Domain.Infrastructure.Databases;
using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;
using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;
using MediatR;

namespace HeadHunterAggregator.Services.Vacancy.UseCases.Commands
{
    public class ImportHeadHunterIndustriesCommand : IRequest<bool>
    {
        public IReadOnlyCollection<IndustryDto> Industries { get; }

        public ImportHeadHunterIndustriesCommand(IReadOnlyCollection<IndustryDto> industries)
        {
            Industries = industries;   
        }

        internal class Validator : AbstractValidator<ImportHeadHunterIndustriesCommand>
        {
            public Validator()
            {

            }
        }

        internal class Handler : IRequestHandler<ImportHeadHunterIndustriesCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IIndustryRepository _repository;

            public Handler(IUnitOfWork unitOfWork, IIndustryRepository repository)
            {
                _unitOfWork = unitOfWork;
                _repository = repository;
            }

            public async Task<bool> Handle(ImportHeadHunterIndustriesCommand request, 
                CancellationToken cancellationToken)
            {
                using (var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken))
                {
                    try
                    {
                        await SaveIndustries(request.Industries, null, cancellationToken);

                        await _unitOfWork.SaveChangesAsync(cancellationToken);

                        await transaction.CommitAsync(cancellationToken);

                        return true;
                    }
                    catch
                    {
                        await transaction.RollbackAsync(cancellationToken);

                        return false;
                    }
                }
            }

            private async Task SaveIndustries(IReadOnlyCollection<IndustryDto> industries, Guid? parentId,
                CancellationToken cancellationToken = default)
            {
                foreach (var industry in industries)
                {
                    var item = await _repository.FindOneByHeadHunterIdOrAddAsync(
                        new Industry() { ParentId = parentId, Name = industry.Name, HeadHunterId = industry.Id },
                            industry.Id, cancellationToken);

                    if (industry.Industries?.Count > 0)
                    {
                        await SaveIndustries(industry.Industries, item.Id, cancellationToken);
                    }
                }
            }
        }
    }
}
