using HeadHunter.Database.MongoDb.Common;
using MongoDB.Driver;

namespace HeadHunter.Database.MongoDb.Collections.Extensions.Aggregate
{
    public static class VacancyAggregateExtensions
    {
        private static Repository _repository;

        public static void Init(Repository repository)
        {
            _repository = repository;
        }

        public static IAggregateFluent<Vacancy> WithAll(this IAggregateFluent<Vacancy> aggregate)
        {
            return aggregate.WithArea().WithEmployer().WithSchedule().WithExperience().WithEmployment()
                .WithDepartment().WithVacancyType().WithBillingType().WithCurrency().WithLanguages()
                .WithKeySkills().WithWorkingDays().WithSpecializations().WithWorkingTimeModes()
                .WithProfessionalRoles().WithDriverLicenseTypes().WithWorkingTimeIntervals();
        }

        public static IAggregateFluent<Vacancy> WithArea(this IAggregateFluent<Vacancy> aggregate)
        {
            return aggregate
                .Lookup<Vacancy, Area, Vacancy>(_repository.GetCollection<Area>(), vacancy => vacancy.AreaId, area => area.Id, vacancy => vacancy.Area)
                .Unwind<Vacancy, Vacancy>(vacancy => vacancy.Area);
        }

        public static IAggregateFluent<Vacancy> WithEmployer(this IAggregateFluent<Vacancy> aggregate)
        {
            return aggregate
                .Lookup<Vacancy, Employer, Vacancy>(_repository.GetCollection<Employer>(), vacancy => vacancy.EmployerId, employer => employer.Id, vacancy => vacancy.Employer)
                .Unwind<Vacancy, Vacancy>(vacancy => vacancy.Employer);
        }

        public static IAggregateFluent<Vacancy> WithSchedule(this IAggregateFluent<Vacancy> aggregate)
        {
            return aggregate
                .Lookup<Vacancy, Schedule, Vacancy>(_repository.GetCollection<Schedule>(), vacancy => vacancy.ScheduleId, schedule => schedule.Id, vacancy => vacancy.Schedule)
                .Unwind<Vacancy, Vacancy>(vacancy => vacancy.Schedule);
        }

        public static IAggregateFluent<Vacancy> WithExperience(this IAggregateFluent<Vacancy> aggregate)
        {
            return aggregate
                .Lookup<Vacancy, Experience, Vacancy>(_repository.GetCollection<Experience>(), vacancy => vacancy.ExperienceId, experience => experience.Id, vacancy => vacancy.Experience)
                .Unwind<Vacancy, Vacancy>(vacancy => vacancy.Experience);
        }

        public static IAggregateFluent<Vacancy> WithEmployment(this IAggregateFluent<Vacancy> aggregate)
        {
            return aggregate
                .Lookup<Vacancy, Employment, Vacancy>(_repository.GetCollection<Employment>(), vacancy => vacancy.EmploymentId, employment => employment.Id, vacancy => vacancy.Employment)
                .Unwind<Vacancy, Vacancy>(vacancy => vacancy.Employment);
        }

        public static IAggregateFluent<Vacancy> WithDepartment(this IAggregateFluent<Vacancy> aggregate)
        {
            return aggregate
                .Lookup<Vacancy, Department, Vacancy>(_repository.GetCollection<Department>(), vacancy => vacancy.DepartmentId, department => department.Id, vacancy => vacancy.Department)
                .Unwind<Vacancy, Vacancy>(vacancy => vacancy.Department);
        }

        public static IAggregateFluent<Vacancy> WithVacancyType(this IAggregateFluent<Vacancy> aggregate)
        {
            return aggregate
                .Lookup<Vacancy, VacancyType, Vacancy>(_repository.GetCollection<VacancyType>(), vacancy => vacancy.VacancyTypeId, vacancyType => vacancyType.Id, vacancy => vacancy.VacancyType)
                .Unwind<Vacancy, Vacancy>(vacancy => vacancy.VacancyType);
        }

        public static IAggregateFluent<Vacancy> WithBillingType(this IAggregateFluent<Vacancy> aggregate)
        {
            return aggregate
                .Lookup<Vacancy, BillingType, Vacancy>(_repository.GetCollection<BillingType>(), vacancy => vacancy.BillingTypeId, billingType => billingType.Id, vacancy => vacancy.BillingType)
                .Unwind<Vacancy, Vacancy>(vacancy => vacancy.BillingType);
        }

        public static IAggregateFluent<Vacancy> WithCurrency(this IAggregateFluent<Vacancy> aggregate)
        {
            return aggregate
                .Lookup<Vacancy, Currency, Vacancy>(_repository.GetCollection<Currency>(), vacancy => vacancy.Salary.CurrencyId, currency => currency.Id, vacancy => vacancy.Salary.Currency)
                .Unwind<Vacancy, Vacancy>(vacancy => vacancy.Salary.Currency);
        }

        public static IAggregateFluent<Vacancy> WithLanguages(this IAggregateFluent<Vacancy> aggregate)
        {
            return aggregate.Lookup<Vacancy, Language, Vacancy>(_repository.GetCollection<Language>(), vacancy => vacancy.LanguagesIds, language => language.Id, vacancy => vacancy.Languages);
        }

        public static IAggregateFluent<Vacancy> WithKeySkills(this IAggregateFluent<Vacancy> aggregate)
        {
            return aggregate.Lookup<Vacancy, KeySkill, Vacancy>(_repository.GetCollection<KeySkill>(), vacancy => vacancy.KeySkillsIds, keySkill => keySkill.Id, vacancy => vacancy.KeySkills);
        }

        public static IAggregateFluent<Vacancy> WithWorkingDays(this IAggregateFluent<Vacancy> aggregate)
        {
            return aggregate.Lookup<Vacancy, WorkingDay, Vacancy>(_repository.GetCollection<WorkingDay>(), vacancy => vacancy.WorkingDaysIds, workingDay => workingDay.Id, vacancy => vacancy.WorkingDays);
        }

        public static IAggregateFluent<Vacancy> WithSpecializations(this IAggregateFluent<Vacancy> aggregate)
        {
            return aggregate.Lookup<Vacancy, Specialization, Vacancy>(_repository.GetCollection<Specialization>(), vacancy => vacancy.SpecializationsIds, specialization => specialization.Id, vacancy => vacancy.Specializations);
        }

        public static IAggregateFluent<Vacancy> WithWorkingTimeModes(this IAggregateFluent<Vacancy> aggregate)
        {
            return aggregate.Lookup<Vacancy, WorkingTimeMode, Vacancy>(_repository.GetCollection<WorkingTimeMode>(), vacancy => vacancy.WorkingTimeModesIds, workingTimeMode => workingTimeMode.Id, vacancy => vacancy.WorkingTimeModes);
        }

        public static IAggregateFluent<Vacancy> WithProfessionalRoles(this IAggregateFluent<Vacancy> aggregate)
        {
            return aggregate.Lookup<Vacancy, ProfessionalRole, Vacancy>(_repository.GetCollection<ProfessionalRole>(), vacancy => vacancy.ProfessionalRolesIds, professionalRole => professionalRole.Id, vacancy => vacancy.ProfessionalRoles);
        }

        public static IAggregateFluent<Vacancy> WithDriverLicenseTypes(this IAggregateFluent<Vacancy> aggregate)
        {
            return aggregate.Lookup<Vacancy, DriverLicenseType, Vacancy>(_repository.GetCollection<DriverLicenseType>(), vacancy => vacancy.DriverLicenseTypesIds, driverLicenseType => driverLicenseType.Id, vacancy => vacancy.DriverLicenseTypes);
        }

        public static IAggregateFluent<Vacancy> WithWorkingTimeIntervals(this IAggregateFluent<Vacancy> aggregate)
        {
            return aggregate.Lookup<Vacancy, WorkingTimeInterval, Vacancy>(_repository.GetCollection<WorkingTimeInterval>(), vacancy => vacancy.WorkingTimeIntervalsIds, workingTimeInterval => workingTimeInterval.Id, vacancy => vacancy.WorkingTimeIntervals);
        }
    }
}
