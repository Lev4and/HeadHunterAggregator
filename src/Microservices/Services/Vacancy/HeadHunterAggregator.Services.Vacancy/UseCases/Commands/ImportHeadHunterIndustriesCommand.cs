using FluentValidation;
using HeadHunterAggregator.Domain.Infrastructure.Databases;
using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Mappers;
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
            private readonly IIndustryMapper _industryMapper;
            private readonly IIndustryRepository _industryRepository;

            public Handler(IUnitOfWork unitOfWork, IIndustryMapper industryMapper, IIndustryRepository industryRepository)
            {
                _unitOfWork = unitOfWork;
                _industryMapper = industryMapper;
                _industryRepository = industryRepository;
            }

            public async Task<bool> Handle(ImportHeadHunterIndustriesCommand request, 
                CancellationToken cancellationToken)
            {
                using (var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken))
                {
                    try
                    {
                        await ImportIndustriesAsync(request.Industries, null, cancellationToken);

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

            private async Task ImportIndustriesAsync(IReadOnlyCollection<IndustryDto> industries, Guid? parentId,
                CancellationToken cancellationToken = default)
            {
                foreach (var industry in industries)
                {
                    var entity = _industryMapper.Map(industry);

                    entity.ParentId = parentId;

                    var item = await _industryRepository.FindOneByHeadHunterIdOrAddAsync(entity, industry.Id, 
                        cancellationToken);

                    if (industry.Industries?.Count > 0)
                    {
                        await ImportIndustriesAsync(industry.Industries, item.Id, cancellationToken);
                    }
                }
            }
        }
    }
}
