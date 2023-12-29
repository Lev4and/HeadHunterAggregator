using FluentValidation;
using HeadHunterAggregator.Domain.Infrastructure.Databases;
using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;
using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;
using MediatR;

namespace HeadHunterAggregator.Services.Vacancy.UseCases.Commands
{
    public class ImportHeadHunterSpecializationsCommand : IRequest<bool>
    {
        public IReadOnlyCollection<SpecializationDto> Specializations { get; }

        public ImportHeadHunterSpecializationsCommand(IReadOnlyCollection<SpecializationDto> specializations)
        {
            Specializations = specializations;
        }

        internal class Validator : AbstractValidator<ImportHeadHunterSpecializationsCommand>
        {
            public Validator()
            {

            }
        }

        internal class Handler : IRequestHandler<ImportHeadHunterSpecializationsCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly ISpecializationRepository _repository;

            public Handler(IUnitOfWork unitOfWork, ISpecializationRepository repository)
            {
                _unitOfWork = unitOfWork;
                _repository = repository;
            }

            public async Task<bool> Handle(ImportHeadHunterSpecializationsCommand request, 
                CancellationToken cancellationToken)
            {
                using (var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken))
                {
                    try
                    {
                        await SaveSpecializations(request.Specializations, null, cancellationToken);

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

            private async Task SaveSpecializations(IReadOnlyCollection<SpecializationDto> specializations, Guid? parentId,
                CancellationToken cancellationToken = default)
            {
                foreach (var specialization in specializations)
                {
                    var item = await _repository.FindOneByHeadHunterIdOrAddAsync(
                        new Specialization() { ParentId = parentId, Laboring = specialization.Laboring, 
                                Name = specialization.Name, HeadHunterId = specialization.Id },
                                    specialization.Id, cancellationToken);

                    if (specialization.Specializations?.Count > 0)
                    {
                        await SaveSpecializations(specialization.Specializations, item.Id, cancellationToken);
                    }
                }
            }
        }
    }
}
