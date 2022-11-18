using HeadHunter.Database.PostgreSQL.Common.Extensions;
using HeadHunter.Database.PostgreSQL.Entities;
using Microsoft.EntityFrameworkCore;

namespace HeadHunter.Database.PostgreSQL
{
    public static class BinderModels
    {
        public static void BindModels(this ModelBuilder builder)
        {
            builder.BindAddressModel();
            builder.BindAreaModel();
            builder.BindBillingTypeModel();
            builder.BindCurrencyModel();
            builder.BindDepartmentModel();
            builder.BindDriverLicenseTypeModel();
            builder.BindEmployerModel();
            builder.BindEmployerTypeModel();
            builder.BindEmploymentModel();
            builder.BindExperienceModel();
            builder.BindIndustryModel();
            builder.BindInsiderInterviewModel();
            builder.BindKeySkillModel();
            builder.BindLanguageModel();
            builder.BindMetroLineModel();
            builder.BindPhoneModel();
            builder.BindProfessionalRoleModel();
            builder.BindScheduleModel();
            builder.BindSpecializationModel();
            builder.BindVacancyModel();
            builder.BindVacancyContactModel();
            builder.BindVacancyTypeModel();
            builder.BindWorkingDayModel();
            builder.BindWorkingTimeIntervalModel();
            builder.BindWorkingTimeModeModel();
        }

        private static void BindAddressModel(this ModelBuilder builder)
        {
            builder.Entity<Address>().OneToMany(entity => entity.Vacancies, entity => entity.Address, entity => entity.AddressId);
        }

        private static void BindAreaModel(this ModelBuilder builder)
        {
            builder.Entity<Area>().OneToMany(entity => entity.Children, entity => entity.Parent, entity => entity.ParentId, false);

            builder.Entity<Area>().OneToMany(entity => entity.Vacancies, entity => entity.Area, entity => entity.AreaId);

            builder.Entity<Area>().OneToMany(entity => entity.Employers, entity => entity.Area, entity => entity.AreaId);

            builder.Entity<Area>().OneToMany(entity => entity.MetroLines, entity => entity.Area, entity => entity.AreaId, false);
        }

        private static void BindBillingTypeModel(this ModelBuilder builder)
        {
            builder.Entity<BillingType>().OneToMany(entity => entity.Vacancies, entity => entity.BillingType, entity => entity.BillingTypeId);
        }

        private static void BindCurrencyModel(this ModelBuilder builder)
        {
            builder.Entity<Currency>().OneToMany(entity => entity.Salaries, entity => entity.Currency, entity => entity.CurrencyId);
        }

        private static void BindDepartmentModel(this ModelBuilder builder)
        {
            builder.Entity<Department>().OneToMany(entity => entity.Vacancies, entity => entity.Department, entity => entity.DepartmentId, false);
        }

        private static void BindDriverLicenseTypeModel(this ModelBuilder builder)
        {
            builder.Entity<DriverLicenseType>().OneToMany(entity => entity.Vacancies, entity => entity.DriverLicenseType, entity => entity.DriverLicenseTypeId);
        }

        private static void BindEmployerModel(this ModelBuilder builder)
        {
            builder.Entity<Employer>().OneToOne(entity => entity.Logo, entity => entity.Employer, entity => entity.EmployerId);

            builder.Entity<Employer>().OneToOne(entity => entity.Description, entity => entity.Employer, entity => entity.EmployerId);

            builder.Entity<Employer>().OneToOne(entity => entity.BrandedDescription, entity => entity.Employer, entity => entity.EmployerId);

            builder.Entity<Employer>().OneToMany(entity => entity.Vacancies, entity => entity.Employer, entity => entity.EmployerId);

            builder.Entity<Employer>().OneToMany(entity => entity.Industries, entity => entity.Employer, entity => entity.EmployerId);

            builder.Entity<Employer>().OneToMany(entity => entity.InsiderInterviews, entity => entity.Employer, entity => entity.EmployerId);
        }

        private static void BindEmployerTypeModel(this ModelBuilder builder)
        {
            builder.Entity<EmployerType>().OneToMany(entity => entity.Employers, entity => entity.Type, entity => entity.TypeId);
        }

        private static void BindEmploymentModel(this ModelBuilder builder)
        {
            builder.Entity<Employment>().OneToMany(entity => entity.Vacancies, entity => entity.Employment, entity => entity.EmploymentId);
        }

        private static void BindExperienceModel(this ModelBuilder builder)
        {
            builder.Entity<Experience>().OneToMany(entity => entity.Vacancies, entity => entity.Experience, entity => entity.ExperienceId);
        }

        private static void BindIndustryModel(this ModelBuilder builder)
        {
            builder.Entity<Industry>().OneToMany(entity => entity.Children, entity => entity.Parent, entity => entity.ParentId, false);

            builder.Entity<Industry>().OneToMany(entity => entity.Employers, entity => entity.Industry, entity => entity.IndustryId);
        }

        private static void BindInsiderInterviewModel(this ModelBuilder builder)
        {
            builder.Entity<InsiderInterview>().OneToMany(entity => entity.Vacancies, entity => entity.InsiderInterview, entity => entity.InsiderInterviewId, false);

            builder.Entity<InsiderInterview>().OneToMany(entity => entity.Employers, entity => entity.InsiderInterview, entity => entity.InsiderInterviewId);
        }

        private static void BindKeySkillModel(this ModelBuilder builder)
        {
            builder.Entity<KeySkill>().OneToMany(entity => entity.Vacancies, entity => entity.KeySkill, entity => entity.KeySkillId);
        }

        private static void BindLanguageModel(this ModelBuilder builder)
        {
            builder.Entity<Language>().OneToMany(entity => entity.Vacancies, entity => entity.Language, entity => entity.LanguageId);
        }

        private static void BindMetroLineModel(this ModelBuilder builder)
        {
            builder.Entity<MetroLine>().OneToMany(entity => entity.Stations, entity => entity.Line, entity => entity.MetroLineId);
        }

        private static void BindPhoneModel(this ModelBuilder builder)
        {
            builder.Entity<Phone>().OneToMany(entity => entity.VacancyContacts, entity => entity.Phone, entity => entity.PhoneId);
        }

        private static void BindProfessionalRoleModel(this ModelBuilder builder)
        {
            builder.Entity<ProfessionalRole>().OneToMany(entity => entity.Vacancies, entity => entity.ProfessionalRole, entity => entity.ProfessionalRoleId);
        }

        private static void BindScheduleModel(this ModelBuilder builder)
        {
            builder.Entity<Schedule>().OneToMany(entity => entity.Vacancies, entity => entity.Schedule, entity => entity.ScheduleId);
        }

        private static void BindSpecializationModel(this ModelBuilder builder)
        {
            builder.Entity<Specialization>().OneToMany(entity => entity.Children, entity => entity.Parent, entity => entity.ParentId, false);

            builder.Entity<Specialization>().OneToMany(entity => entity.Vacancies, entity => entity.Specialization, entity => entity.SpecializationId);
        }

        private static void BindVacancyModel(this ModelBuilder builder)
        {
            builder.Entity<Vacancy>().OneToOne(entity => entity.Salary, entity => entity.Vacancy, entity => entity.VacancyId);

            builder.Entity<Vacancy>().OneToOne(entity => entity.Contact, entity => entity.Vacancy, entity => entity.VacancyId);

            builder.Entity<Vacancy>().OneToOne(entity => entity.Description, entity => entity.Vacancy, entity => entity.VacancyId);

            builder.Entity<Vacancy>().OneToOne(entity => entity.BrandedDescription, entity => entity.Vacancy, entity => entity.VacancyId);

            builder.Entity<Vacancy>().OneToMany(entity => entity.Languages, entity => entity.Vacancy, entity => entity.VacancyId);

            builder.Entity<Vacancy>().OneToMany(entity => entity.KeySkills, entity => entity.Vacancy, entity => entity.VacancyId);

            builder.Entity<Vacancy>().OneToMany(entity => entity.WorkingDays, entity => entity.Vacancy, entity => entity.VacancyId);

            builder.Entity<Vacancy>().OneToMany(entity => entity.Specializations, entity => entity.Vacancy, entity => entity.VacancyId);

            builder.Entity<Vacancy>().OneToMany(entity => entity.WorkingTimeModes, entity => entity.Vacancy, entity => entity.VacancyId);

            builder.Entity<Vacancy>().OneToMany(entity => entity.ProfessionalRoles, entity => entity.Vacancy, entity => entity.VacancyId);

            builder.Entity<Vacancy>().OneToMany(entity => entity.DriverLicenseTypes, entity => entity.Vacancy, entity => entity.VacancyId);

            builder.Entity<Vacancy>().OneToMany(entity => entity.WorkingTimeIntervals, entity => entity.Vacancy, entity => entity.VacancyId);
        }

        private static void BindVacancyContactModel(this ModelBuilder builder)
        {
            builder.Entity<VacancyContact>().OneToMany(entity => entity.Phones, entity => entity.Contact, entity => entity.ContactId);
        }

        private static void BindVacancyTypeModel(this ModelBuilder builder)
        {
            builder.Entity<VacancyType>().OneToMany(entity => entity.Vacancies, entity => entity.Type, entity => entity.TypeId, false);
        }

        private static void BindWorkingDayModel(this ModelBuilder builder)
        {
            builder.Entity<WorkingDay>().OneToMany(entity => entity.Vacancies, entity => entity.WorkingDay, entity => entity.WorkingDayId);
        }

        private static void BindWorkingTimeIntervalModel(this ModelBuilder builder)
        {
            builder.Entity<WorkingTimeInterval>().OneToMany(entity => entity.Vacancies, entity => entity.WorkingTimeInterval, entity => entity.WorkingTimeIntervalId);
        }

        private static void BindWorkingTimeModeModel(this ModelBuilder builder)
        {
            builder.Entity<WorkingTimeMode>().OneToMany(entity => entity.Vacancies, entity => entity.WorkingTimeMode, entity => entity.WorkingTimeModeId);
        }
    }
}
