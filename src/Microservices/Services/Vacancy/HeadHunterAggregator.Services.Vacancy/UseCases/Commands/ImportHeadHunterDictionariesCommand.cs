using FluentValidation;
using HeadHunterAggregator.Domain.Entities;
using HeadHunterAggregator.Domain.Infrastructure.Databases;
using HeadHunterAggregator.Domain.Infrastructure.Databases.Mappers;
using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;
using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Mappers;
using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;
using MediatR;

namespace HeadHunterAggregator.Services.Vacancy.UseCases.Commands
{
    public class ImportHeadHunterDictionariesCommand : IRequest<bool>
    {
        public DictionariesDto Dictionaries { get; }

        public ImportHeadHunterDictionariesCommand(DictionariesDto dictionaries)
        {
            Dictionaries = dictionaries;
        }

        internal class Validator : AbstractValidator<ImportHeadHunterDictionariesCommand>
        {
            public Validator()
            {

            }
        }

        internal class Handler : IRequestHandler<ImportHeadHunterDictionariesCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;

            private readonly IDbMappers _dbMappers;
            private readonly IFromHeadHunterRepository _fromHeadHunterRepository;

            public Handler(IUnitOfWork unitOfWork, IDbMappers dbMappers, 
                IFromHeadHunterRepository fromHeadHunterRepository)
            {
                _unitOfWork = unitOfWork;

                _dbMappers = dbMappers;
                _fromHeadHunterRepository = fromHeadHunterRepository;
            }

            public async Task<bool> Handle(ImportHeadHunterDictionariesCommand request,
                CancellationToken cancellationToken)
            {
                using (var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken))
                {
                    try
                    {
                        await ImportAsync<BillingTypeDto, BillingType>(request.Dictionaries.VacancyBillingTypes, 
                            item => item.Id, cancellationToken);

                        await ImportAsync<CurrencyDto, Currency>(request.Dictionaries.Currencies, item => item.Code, 
                            cancellationToken);

                        await ImportAsync<DriverLicenseTypeDto, DriverLicenseType>(request.Dictionaries.DriverLicenseTypes, 
                            item => item.Id, cancellationToken);

                        await ImportAsync<EmployerTypeDto, EmployerType>(request.Dictionaries.EmployerTypes, item => item.Id, 
                            cancellationToken);

                        await ImportAsync<EmploymentDto, Employment>(request.Dictionaries.Employments, item => item.Id, 
                            cancellationToken);

                        await ImportAsync<ExperienceDto, Experience>(request.Dictionaries.Experiences, item => item.Id, 
                            cancellationToken);

                        await ImportAsync<ScheduleDto, Schedule>(request.Dictionaries.Schedules, item => item.Id, 
                            cancellationToken);

                        await ImportAsync<VacancyTypeDto, VacancyType>(request.Dictionaries.VacancyTypes, item => item.Id, 
                            cancellationToken);

                        await ImportAsync<WorkingDayDto, WorkingDay>(request.Dictionaries.WorkingDays, item => item.Id, 
                            cancellationToken);

                        await ImportAsync<WorkingTimeIntervalDto, WorkingTimeInterval>(request.Dictionaries.WorkingTimeIntervals, 
                            item => item.Id, cancellationToken);

                        await ImportAsync<WorkingTimeModeDto, WorkingTimeMode>(request.Dictionaries.WorkingTimeModes, 
                            item => item.Id, cancellationToken);

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

            private async Task ImportAsync<TDto, TEntity>(IReadOnlyCollection<TDto> items, Func<TDto, string> headHunterIdFunc, 
                    CancellationToken cancellationToken = default) 
                where TDto : class 
                where TEntity : EntityBase, IFromHeadHunter
            {
                var mapper = _dbMappers.GetDbMapper<TDto, TEntity>();

                foreach (var item in items)
                {
                    await _fromHeadHunterRepository.FindOneByHeadHunterIdOrAddAsync(mapper.Map(item), 
                        headHunterIdFunc(item), cancellationToken);
                }
            }
        }
    }
}
