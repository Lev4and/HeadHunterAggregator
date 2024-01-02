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

            private readonly IBillingTypeMapper _billingTypeMapper;
            private readonly ICurrencyMapper _currencyMapper;
            private readonly IDriverLicenseTypeMapper _driverLicenseTypeMapper;
            private readonly IEmployerTypeMapper _employerTypeMapper;
            private readonly IEmploymentMapper _employmentMapper;
            private readonly IExperienceMapper _experienceMapper;
            private readonly IScheduleMapper _scheduleMapper;
            private readonly IVacancyTypeMapper _vacancyTypeMapper;
            private readonly IWorkingDayMapper _workingDayMapper;
            private readonly IWorkingTimeIntervalMapper _workingTimeIntervalMapper;
            private readonly IWorkingTimeModeMapper _workingTimeModeMapper;


            private readonly IBillingTypeRepository _billingTypeRepository;
            private readonly ICurrencyRepository _currencyRepository;
            private readonly IDriverLicenseTypeRepository _driverLicenseTypeRepository;
            private readonly IEmployerTypeRepository _employerTypeRepository;
            private readonly IEmploymentRepository _employmentRepository;
            private readonly IExperienceRepository _experienceRepository;
            private readonly IScheduleRepository _scheduleRepository;
            private readonly IVacancyTypeRepository _vacancyTypeRepository;
            private readonly IWorkingDayRepository _workingDayRepository;
            private readonly IWorkingTimeIntervalRepository _workingTimeIntervalRepository;
            private readonly IWorkingTimeModeRepository _workingTimeModeRepository;

            public Handler(IUnitOfWork unitOfWork, IBillingTypeMapper billingTypeMapper, ICurrencyMapper currencyMapper, 
                IDriverLicenseTypeMapper driverLicenseTypeMapper, IEmployerTypeMapper employerTypeMapper, 
                IEmploymentMapper employmentMapper, IExperienceMapper experienceMapper, IScheduleMapper scheduleMapper, 
                IVacancyTypeMapper vacancyTypeMapper, IWorkingDayMapper workingDayMapper,
                IWorkingTimeIntervalMapper workingTimeIntervalMapper, IWorkingTimeModeMapper workingTimeModeMapper, 
                IBillingTypeRepository billingTypeRepository, ICurrencyRepository currencyRepository, 
                IDriverLicenseTypeRepository driverLicenseTypeRepository, IEmployerTypeRepository employerTypeRepository, 
                IEmploymentRepository employmentRepository, IExperienceRepository experienceRepository, 
                IScheduleRepository scheduleRepository, IVacancyTypeRepository vacancyTypeRepository, 
                IWorkingDayRepository workingDayRepository, IWorkingTimeIntervalRepository workingTimeIntervalRepository, 
                IWorkingTimeModeRepository workingTimeModeRepository)
            {
                _unitOfWork = unitOfWork;

                _billingTypeMapper = billingTypeMapper;
                _currencyMapper = currencyMapper;
                _driverLicenseTypeMapper = driverLicenseTypeMapper;
                _employerTypeMapper = employerTypeMapper;
                _employmentMapper = employmentMapper;
                _experienceMapper = experienceMapper;
                _scheduleMapper = scheduleMapper;
                _vacancyTypeMapper = vacancyTypeMapper;
                _workingDayMapper = workingDayMapper;
                _workingTimeIntervalMapper = workingTimeIntervalMapper;
                _workingTimeModeMapper = workingTimeModeMapper;

                _billingTypeRepository = billingTypeRepository;
                _currencyRepository = currencyRepository;
                _driverLicenseTypeRepository = driverLicenseTypeRepository;
                _employerTypeRepository = employerTypeRepository;
                _employmentRepository = employmentRepository;
                _experienceRepository = experienceRepository;
                _scheduleRepository = scheduleRepository;
                _vacancyTypeRepository = vacancyTypeRepository;
                _workingDayRepository = workingDayRepository;
                _workingTimeIntervalRepository = workingTimeIntervalRepository;
                _workingTimeModeRepository = workingTimeModeRepository;
            }

            public async Task<bool> Handle(ImportHeadHunterDictionariesCommand request,
                CancellationToken cancellationToken)
            {
                using (var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken))
                {
                    try
                    {
                        await ImportAsync(request.Dictionaries.VacancyBillingTypes, _billingTypeMapper,
                            item => item.Id, _billingTypeRepository, cancellationToken);

                        await ImportAsync(request.Dictionaries.Currencies, _currencyMapper,
                            item => item.Code, _currencyRepository, cancellationToken);

                        await ImportAsync(request.Dictionaries.DriverLicenseTypes, _driverLicenseTypeMapper,
                            item => item.Id, _driverLicenseTypeRepository, cancellationToken);

                        await ImportAsync(request.Dictionaries.EmployerTypes, _employerTypeMapper,
                            item => item.Id, _employerTypeRepository, cancellationToken);

                        await ImportAsync(request.Dictionaries.Employments, _employmentMapper,
                            item => item.Id, _employmentRepository, cancellationToken);

                        await ImportAsync(request.Dictionaries.Experiences, _experienceMapper,
                            item => item.Id, _experienceRepository, cancellationToken);

                        await ImportAsync(request.Dictionaries.Schedules, _scheduleMapper,
                            item => item.Id, _scheduleRepository, cancellationToken);

                        await ImportAsync(request.Dictionaries.VacancyTypes, _vacancyTypeMapper,
                            item => item.Id, _vacancyTypeRepository, cancellationToken);

                        await ImportAsync(request.Dictionaries.WorkingDays, _workingDayMapper,
                            item => item.Id, _workingDayRepository, cancellationToken);

                        await ImportAsync(request.Dictionaries.WorkingTimeIntervals, _workingTimeIntervalMapper,
                            item => item.Id, _workingTimeIntervalRepository, cancellationToken);

                        await ImportAsync(request.Dictionaries.WorkingTimeModes, _workingTimeModeMapper,
                            item => item.Id, _workingTimeModeRepository, cancellationToken);

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

            private async Task ImportAsync<TDto, TEntity>(IReadOnlyCollection<TDto> items, 
                IMapper<TDto, TEntity> mapper, Func<TDto, string> headHunterIdFunc, 
                    IFromHeadHunterRepository<TEntity> repository, CancellationToken cancellationToken = default) 
                        where TDto : class where TEntity : EntityBase, IFromHeadHunter
            {
                foreach (var item in items)
                {
                    await repository.FindOneByHeadHunterIdOrAddAsync(mapper.Map(item), headHunterIdFunc(item),
                        cancellationToken);
                }
            }
        }
    }
}
