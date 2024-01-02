using FluentValidation;
using HeadHunterAggregator.Domain.Infrastructure.Databases;
using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Mappers;
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
            private readonly ISpecializationMapper _specializationMapper;
            private readonly ISpecializationRepository _specializationRepository;

            public Handler(IUnitOfWork unitOfWork, ISpecializationMapper specializationMapper, 
                ISpecializationRepository specializationRepository)
            {
                _unitOfWork = unitOfWork;
                _specializationMapper = specializationMapper;
                _specializationRepository = specializationRepository;
            }

            public async Task<bool> Handle(ImportHeadHunterSpecializationsCommand request, 
                CancellationToken cancellationToken)
            {
                using (var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken))
                {
                    try
                    {
                        await ImportSpecializationsAsync(request.Specializations, null, cancellationToken);

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

            private async Task ImportSpecializationsAsync(IReadOnlyCollection<SpecializationDto> specializations, 
                Guid? parentId, CancellationToken cancellationToken = default)
            {
                foreach (var specialization in specializations)
                {
                    var entity = _specializationMapper.Map(specialization);

                    entity.ParentId = parentId;

                    var item = await _specializationRepository.FindOneByHeadHunterIdOrAddAsync(entity,
                        specialization.Id, cancellationToken);

                    if (specialization.Specializations?.Count > 0)
                    {
                        await ImportSpecializationsAsync(specialization.Specializations, item.Id, cancellationToken);
                    }
                }
            }
        }
    }
}
