using FluentValidation;
using HeadHunterAggregator.Domain.Infrastructure.Databases;
using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Mappers;
using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;
using MediatR;

namespace HeadHunterAggregator.Services.Vacancy.UseCases.Commands
{
    public class ImportHeadHunterAreasCommand : IRequest<bool>
    {
        public IReadOnlyCollection<AreaDto> Areas { get; }

        public ImportHeadHunterAreasCommand(IReadOnlyCollection<AreaDto> areas)
        {
            Areas = areas;
        }

        internal class Validator : AbstractValidator<ImportHeadHunterAreasCommand>
        {
            public Validator()
            {
                
            }
        }

        internal class Handler : IRequestHandler<ImportHeadHunterAreasCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IAreaMapper _areaMapper;
            private readonly IAreaRepository _areaRepository;

            public Handler(IUnitOfWork unitOfWork, IAreaMapper areaMapper, IAreaRepository areaRepository)
            {
                _unitOfWork = unitOfWork;
                _areaMapper = areaMapper;
                _areaRepository = areaRepository;
            }

            public async Task<bool> Handle(ImportHeadHunterAreasCommand request, 
                CancellationToken cancellationToken)
            {
                using (var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken))
                {
                    try
                    {
                        await ImportAreasAsync(request.Areas, null, cancellationToken);

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

            private async Task ImportAreasAsync(IReadOnlyCollection<AreaDto> areas, Guid? parentId,
                CancellationToken cancellationToken = default)
            {
                foreach (var area in areas)
                {
                    var entity = _areaMapper.Map(area);

                    entity.ParentId = parentId;

                    var item = await _areaRepository.FindOneByHeadHunterIdOrAddAsync(entity, area.Id, 
                        cancellationToken);

                    if (area.Areas?.Count > 0)
                    {
                        await ImportAreasAsync(area.Areas, item.Id, cancellationToken);
                    }
                }
            }
        }
    }
}
