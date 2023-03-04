using Microsoft.Extensions.DependencyInjection;

namespace HeadHunter.Infrastructure.Factories.HeadHunter
{
    internal static class Configure
    {
        public static void AddHeadHunterFactories(this IServiceCollection services)
        {
            services.AddTransient<IAddressFactory, AddressFactory>();
            services.AddSingleton<IAreaFactory, AreaFactory>();
            services.AddSingleton<IBillingTypeFactory, BillingTypeFactory>();
            services.AddSingleton<IContactFactory, ContactFactory>();
            services.AddSingleton<ICurrencyFactory, CurrencyFactory>();
            services.AddSingleton<IDepartmentFactory, DepartmentFactory>();
            services.AddSingleton<IDriverLicenseTypeFactory, DriverLicenseTypeFactory>();
            services.AddSingleton<IEmployerFactory, EmployerFactory>();
            services.AddSingleton<IEmployerLogoFactory, EmployerLogoFactory>();
            services.AddSingleton<IEmploymentFactory, EmploymentFactory>();
            services.AddSingleton<IExperienceFactory, ExperienceFactory>();
            services.AddSingleton<IIndustryFactory, IndustryFactory>();
            services.AddSingleton<IInsiderInterviewFactory, InsiderInterviewFactory>();
            services.AddSingleton<IKeySkillFactory, KeySkillFactory>();
            services.AddSingleton<ILanguageFactory, LanguageFactory>();
            services.AddSingleton<IMetroLineFactory, MetroLineFactory>();
            services.AddSingleton<IMetroStationFactory, MetroStationFactory>();
            services.AddSingleton<IPhoneFactory, PhoneFactory>();
            services.AddSingleton<IProfessionalRoleFactory, ProfessionalRoleFactory>();
            services.AddSingleton<ISalaryFactory, SalaryFactory>();
            services.AddSingleton<IScheduleFactory, ScheduleFactory>();
            services.AddSingleton<ISpecializationFactory, SpecializationFactory>();
            services.AddSingleton<ITestFactory, TestFactory>();
            services.AddSingleton<IVacancyFactory, VacancyFactory>();
            services.AddSingleton<IVacancyTypeFactory, VacancyTypeFactory>();
            services.AddSingleton<IWorkingDayFactory, WorkingDayFactory>();
            services.AddSingleton<IWorkingTimeIntervalFactory, WorkingTimeIntervalFactory>();
            services.AddSingleton<IWorkingTimeModeFactory, WorkingTimeModeFactory>();
        }
    }
}
