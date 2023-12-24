using FluentValidation;
using HeadHunterAggregator.Domain.Infrastructure.Databases;
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
                return await SaveAreasAsync(request.Areas, null, cancellationToken);
            }

            private async Task<bool> SaveAreasAsync(IReadOnlyCollection<AreaDto> areas, Guid? parentAreaId, 
                CancellationToken cancellationToken = default)
            {
                using (var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken))
                {
                    try
                    {
                        foreach (var area in areas)
                        {
                            
                        }

                        await _unitOfWork.SaveChangesAsync(cancellationToken);

                        await transaction.CommitAsync(cancellationToken);

                        foreach (var area in areas)
                        {

                        }

                        return true;
                    }
                    catch
                    {
                        await transaction.RollbackAsync(cancellationToken);

                        return false;
                    }
                }
            }
        }
    }
}
