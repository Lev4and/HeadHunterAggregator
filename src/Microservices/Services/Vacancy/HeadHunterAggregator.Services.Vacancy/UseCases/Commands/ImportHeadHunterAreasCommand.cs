using FluentValidation;
using HeadHunterAggregator.Domain.Infrastructure.Databases;
using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;
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
            private readonly IAreaRepository _repository;

            public Handler(IUnitOfWork unitOfWork, IAreaRepository repository)
            {
                _unitOfWork = unitOfWork;
                _repository = repository;
            }

            public async Task<bool> Handle(ImportHeadHunterAreasCommand request, 
                CancellationToken cancellationToken)
            {
                using (var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken))
                {
                    try
                    {
                        await SaveAreas(request.Areas, null, cancellationToken);

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

            private async Task SaveAreas(IReadOnlyCollection<AreaDto> areas, Guid? parentId,
                CancellationToken cancellationToken = default)
            {
                foreach (var area in areas)
                {
                    var item = await _repository.FindOneByHeadHunterIdOrAddAsync(
                        new Area() { ParentId = parentId, Name = area.Name, HeadHunterId = area.Id }, 
                            area.Id, cancellationToken);

                    if (area.Areas?.Count > 0)
                    {
                        await SaveAreas(area.Areas, item.Id, cancellationToken);
                    }
                }
            }
        }
    }
}
