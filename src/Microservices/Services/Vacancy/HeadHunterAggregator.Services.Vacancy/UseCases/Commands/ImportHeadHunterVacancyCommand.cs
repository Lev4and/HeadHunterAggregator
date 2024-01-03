using FluentValidation;
using HeadHunterAggregator.Domain.Infrastructure.Databases;
using HeadHunterAggregator.Domain.Infrastructure.Databases.Mappers;
using HeadHunterAggregator.Domain.Infrastructure.Databases.Repositories;
using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;
using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;
using MediatR;

namespace HeadHunterAggregator.Services.Vacancy.UseCases.Commands
{
    public class ImportHeadHunterVacancyCommand : IRequest<bool>
    {
        public VacancyDto Vacancy { get; }

        public ImportHeadHunterVacancyCommand(VacancyDto vacancy)
        {
            Vacancy = vacancy;
        }

        internal class Validator : AbstractValidator<ImportHeadHunterVacancyCommand>
        {
            public Validator()
            {

            }
        }

        internal class Handler : IRequestHandler<ImportHeadHunterVacancyCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;

            private readonly IDbMappers _dbMappers;

            private readonly IRepository _repository;
            private readonly IFromHeadHunterRepository _fromHeadHunterRepository;

            public Handler(IUnitOfWork unitOfWork, IDbMappers dbMappers, IRepository repository, 
                IFromHeadHunterRepository fromHeadHunterRepository)
            {
                _unitOfWork = unitOfWork;

                _dbMappers = dbMappers;

                _repository = repository;
                _fromHeadHunterRepository = fromHeadHunterRepository;
            }

            public async Task<bool> Handle(ImportHeadHunterVacancyCommand request, CancellationToken cancellationToken)
            {
                using (var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken))
                {
                    try
                    {
                        var employer = await _repository.FindOneByExpressionAsync<Employer>(employer =>
                            employer.HeadHunterId == request.Vacancy.Employer.Id, cancellationToken);

                        if (employer == null)
                        {
                            var employerType = await _repository.FindOneByExpressionAsync<EmployerType>(employerType =>
                                employerType.HeadHunterId == request.Vacancy.Employer.Type, cancellationToken);

                            var area = await _repository.FindOneByExpressionAsync<Area>(area =>
                                area.HeadHunterId == request.Vacancy.Employer.Area.Id, cancellationToken);


                        }

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
        }
    }
}
