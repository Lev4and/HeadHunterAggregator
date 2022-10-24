using HeadHunter.Database.MongoDb.Common;
using MongoDB.Driver;

namespace HeadHunter.Database.MongoDb.Collections.Extensions.Aggregate
{
    public static class VacancyAggregateExtensions
    {
        public static IAggregateFluent<Vacancy> WithAll(this IAggregateFluent<Vacancy> aggregate, Repository repository)
        {
            return aggregate
                .WithArea(repository.GetCollection<Area>())
                .WithEmployer(repository.GetCollection<Employer>())
                .WithSchedule(repository.GetCollection<Schedule>())
                .WithExperience(repository.GetCollection<Experience>())
                .WithEmployment(repository.GetCollection<Employment>())
                .WithDepartment(repository.GetCollection<Department>())
                .WithVacancyType(repository.GetCollection<VacancyType>())
                .WithBillingType(repository.GetCollection<BillingType>())
                .WithCurrency(repository.GetCollection<Currency>())
                .WithLanguages(repository.GetCollection<Language>())
                .WithKeySkills(repository.GetCollection<KeySkill>())
                .WithWorkingDays(repository.GetCollection<WorkingDay>())
                .WithSpecializations(repository.GetCollection<Specialization>())
                .WithWorkingTimeModes(repository.GetCollection<WorkingTimeMode>())
                .WithProfessionalRoles(repository.GetCollection<ProfessionalRole>())
                .WithDriverLicenseTypes(repository.GetCollection<DriverLicenseType>())
                .WithWorkingTimeIntervals(repository.GetCollection<WorkingTimeInterval>());
        }

        public static IAggregateFluent<Vacancy> WithArea(this IAggregateFluent<Vacancy> aggregate, IMongoCollection<Area> collection)
        {
            return aggregate
                .Lookup<Vacancy, Area, Vacancy>(collection, vacancy => vacancy.AreaId, area => area.Id, vacancy => vacancy.Area)
                .Unwind<Vacancy, Vacancy>(vacancy => vacancy.Area);
        }

        public static IAggregateFluent<Vacancy> WithEmployer(this IAggregateFluent<Vacancy> aggregate, IMongoCollection<Employer> collection)
        {
            return aggregate
                .Lookup<Vacancy, Employer, Vacancy>(collection, vacancy => vacancy.EmployerId, employer => employer.Id, vacancy => vacancy.Employer)
                .Unwind<Vacancy, Vacancy>(vacancy => vacancy.Employer);
        }

        public static IAggregateFluent<Vacancy> WithSchedule(this IAggregateFluent<Vacancy> aggregate, IMongoCollection<Schedule> collection)
        {
            return aggregate
                .Lookup<Vacancy, Schedule, Vacancy>(collection, vacancy => vacancy.ScheduleId, schedule => schedule.Id, vacancy => vacancy.Schedule)
                .Unwind<Vacancy, Vacancy>(vacancy => vacancy.Schedule);
        }

        public static IAggregateFluent<Vacancy> WithExperience(this IAggregateFluent<Vacancy> aggregate, IMongoCollection<Experience> collection)
        {
            return aggregate
                .Lookup<Vacancy, Experience, Vacancy>(collection, vacancy => vacancy.ExperienceId, experience => experience.Id, vacancy => vacancy.Experience)
                .Unwind<Vacancy, Vacancy>(vacancy => vacancy.Experience);
        }

        public static IAggregateFluent<Vacancy> WithEmployment(this IAggregateFluent<Vacancy> aggregate, IMongoCollection<Employment> collection)
        {
            return aggregate
                .Lookup<Vacancy, Employment, Vacancy>(collection, vacancy => vacancy.EmploymentId, employment => employment.Id, vacancy => vacancy.Employment)
                .Unwind<Vacancy, Vacancy>(vacancy => vacancy.Employment);
        }

        public static IAggregateFluent<Vacancy> WithDepartment(this IAggregateFluent<Vacancy> aggregate, IMongoCollection<Department> collection)
        {
            return aggregate
                .Lookup<Vacancy, Department, Vacancy>(collection, vacancy => vacancy.DepartmentId, department => department.Id, vacancy => vacancy.Department)
                .Unwind<Vacancy, Vacancy>(vacancy => vacancy.Department);
        }

        public static IAggregateFluent<Vacancy> WithVacancyType(this IAggregateFluent<Vacancy> aggregate, IMongoCollection<VacancyType> collection)
        {
            return aggregate
                .Lookup<Vacancy, VacancyType, Vacancy>(collection, vacancy => vacancy.VacancyTypeId, vacancyType => vacancyType.Id, vacancy => vacancy.VacancyType)
                .Unwind<Vacancy, Vacancy>(vacancy => vacancy.VacancyType);
        }

        public static IAggregateFluent<Vacancy> WithBillingType(this IAggregateFluent<Vacancy> aggregate, IMongoCollection<BillingType> collection)
        {
            return aggregate
                .Lookup<Vacancy, BillingType, Vacancy>(collection, vacancy => vacancy.BillingTypeId, billingType => billingType.Id, vacancy => vacancy.BillingType)
                .Unwind<Vacancy, Vacancy>(vacancy => vacancy.BillingType);
        }

        public static IAggregateFluent<Vacancy> WithCurrency(this IAggregateFluent<Vacancy> aggregate, IMongoCollection<Currency> collection)
        {
            return aggregate
                .Lookup<Vacancy, Currency, Vacancy>(collection, vacancy => vacancy.Salary.CurrencyId, currency => currency.Id, vacancy => vacancy.Salary.Currency)
                .Unwind<Vacancy, Vacancy>(vacancy => vacancy.Salary.Currency);
        }

        public static IAggregateFluent<Vacancy> WithLanguages(this IAggregateFluent<Vacancy> aggregate, IMongoCollection<Language> collection)
        {
            return aggregate.Lookup<Vacancy, Language, Vacancy>(collection, vacancy => vacancy.LanguagesIds, language => language.Id, vacancy => vacancy.Languages);
        }

        public static IAggregateFluent<Vacancy> WithKeySkills(this IAggregateFluent<Vacancy> aggregate, IMongoCollection<KeySkill> collection)
        {
            return aggregate.Lookup<Vacancy, KeySkill, Vacancy>(collection, vacancy => vacancy.KeySkills, keySkill => keySkill.Id, vacancy => vacancy.KeySkills);
        }

        public static IAggregateFluent<Vacancy> WithWorkingDays(this IAggregateFluent<Vacancy> aggregate, IMongoCollection<WorkingDay> collection)
        {
            return aggregate.Lookup<Vacancy, WorkingDay, Vacancy>(collection, vacancy => vacancy.WorkingDaysIds, workingDay => workingDay.Id, vacancy => vacancy.WorkingDays);
        }

        public static IAggregateFluent<Vacancy> WithSpecializations(this IAggregateFluent<Vacancy> aggregate, IMongoCollection<Specialization> collection)
        {
            return aggregate.Lookup<Vacancy, Specialization, Vacancy>(collection, vacancy => vacancy.SpecializationsIds, specialization => specialization.Id, vacancy => vacancy.Specializations);
        }

        public static IAggregateFluent<Vacancy> WithWorkingTimeModes(this IAggregateFluent<Vacancy> aggregate, IMongoCollection<WorkingTimeMode> collection)
        {
            return aggregate.Lookup<Vacancy, WorkingTimeMode, Vacancy>(collection, vacancy => vacancy.WorkingTimeModesIds, workingTimeMode => workingTimeMode.Id, vacancy => vacancy.WorkingTimeModes);
        }

        public static IAggregateFluent<Vacancy> WithProfessionalRoles(this IAggregateFluent<Vacancy> aggregate, IMongoCollection<ProfessionalRole> collection)
        {
            return aggregate.Lookup<Vacancy, ProfessionalRole, Vacancy>(collection, vacancy => vacancy.ProfessionalRolesIds, professionalRole => professionalRole.Id, vacancy => vacancy.ProfessionalRoles);
        }

        public static IAggregateFluent<Vacancy> WithDriverLicenseTypes(this IAggregateFluent<Vacancy> aggregate, IMongoCollection<DriverLicenseType> collection)
        {
            return aggregate.Lookup<Vacancy, DriverLicenseType, Vacancy>(collection, vacancy => vacancy.DriverLicenseTypesIds, driverLicenseType => driverLicenseType.Id, vacancy => vacancy.DriverLicenseTypes);
        }

        public static IAggregateFluent<Vacancy> WithWorkingTimeIntervals(this IAggregateFluent<Vacancy> aggregate, IMongoCollection<WorkingTimeInterval> collection)
        {
            return aggregate.Lookup<Vacancy, WorkingTimeInterval, Vacancy>(collection, vacancy => vacancy.WorkingTimeIntervalsIds, workingTimeInterval => workingTimeInterval.Id, vacancy => vacancy.WorkingTimeIntervals);
        }
    }
}
