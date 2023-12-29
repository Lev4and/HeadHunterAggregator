using HeadHunterAggregator.Domain.Infrastructure.Databases;
using HeadHunterAggregator.Domain.Infrastructure.Databases.Transactions;
using HeadHunterAggregator.Infrastructure.Databases.EntityFramework.Extensions;
using HeadHunterAggregator.Infrastructure.Databases.EntityFramework.Transactions;
using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies
{
    public class VacanciesDbContext : DbContext, IUnitOfWork
    {
        public DbSet<Address> Addresses { get; set; }

        public DbSet<Area> Areas { get; set; }

        public DbSet<BillingType> BillingTypes { get; set; }

        public DbSet<Currency> Currencies { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<DriverLicenseType> DriverLicenseTypes { get; set; }

        public DbSet<Employer> Employers { get; set; }

        public DbSet<EmployerBrandedDescription> EmployerBrandedDescriptions { get; set; }

        public DbSet<EmployerDescription> EmployerDescriptions { get; set; }

        public DbSet<EmployerIndustry> EmployerIndustries { get; set; }

        public DbSet<EmployerInsiderInterview> EmployerInsiderInterviews { get; set; }

        public DbSet<EmployerLogo> EmployerLogos { get; set; }

        public DbSet<EmployerType> EmployerTypes { get; set; }

        public DbSet<Employment> Employments { get; set; }

        public DbSet<Experience> Experiences { get; set; }

        public DbSet<Industry> Industries { get; set; }

        public DbSet<InsiderInterview> InsiderInterviews { get; set; }

        public DbSet<KeySkill> KeySkills { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<MetroLine> MetroLines { get; set; }

        public DbSet<MetroStation> MetroStations { get; set; }

        public DbSet<Phone> Phones { get; set; }

        public DbSet<ProfessionalRole> ProfessionalRoles { get; set; }

        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<Specialization> Specializations { get; set; }

        public DbSet<Entities.Vacancy> Vacancies { get; set; }

        public DbSet<VacancyBrandedDescription> VacancyBrandedDescriptions { get; set; }

        public DbSet<VacancyContact> VacancyContacts { get; set; }

        public DbSet<VacancyContactPhone> VacancyContactPhones { get; set; }

        public DbSet<VacancyDescription> VacancyDescriptions { get; set; }

        public DbSet<VacancyDriverLicenseType> VacancyDriverLicenseTypes { get; set; }

        public DbSet<VacancyKeySkill> VacancyKeySkills { get; set; }

        public DbSet<VacancyLanguage> VacancyLanguages { get; set; }

        public DbSet<VacancyProfessionalRole> VacancyProfessionalRoles { get; set; }

        public DbSet<VacancySalary> VacancySalaries { get; set; }

        public DbSet<VacancySpecialization> VacancySpecializations { get; set; }

        public DbSet<VacancyType> VacancyTypes { get; set; }

        public DbSet<VacancyWorkingDay> VacancyWorkingDays { get; set; }

        public DbSet<VacancyWorkingTimeInterval> VacancyWorkingTimeIntervals { get; set; }

        public DbSet<VacancyWorkingTimeMode> VacancyWorkingTimeModes { get; set; }

        public DbSet<WorkingDay> WorkingDays { get; set; }

        public DbSet<WorkingTimeInterval> WorkingTimeIntervals { get; set; }

        public DbSet<WorkingTimeMode> WorkingTimeModes { get; set; }

        public VacanciesDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        public async Task<IDatabaseTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;

            return new EntityFrameworkDatabaseTransaction(this);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Address>().OneToMany(entity => entity.Vacancies, entity => entity.Address, 
                entity => entity.AddressId);

            modelBuilder.Entity<Area>().OneToMany(entity => entity.Children, entity => entity.Parent, 
                entity => entity.ParentId, false);

            modelBuilder.Entity<Area>().OneToMany(entity => entity.Vacancies, entity => entity.Area, 
                entity => entity.AreaId);

            modelBuilder.Entity<Area>().OneToMany(entity => entity.Employers, entity => entity.Area, 
                entity => entity.AreaId);

            modelBuilder.Entity<Area>().OneToMany(entity => entity.MetroLines, entity => entity.Area, 
                entity => entity.AreaId, false);

            modelBuilder.Entity<BillingType>().OneToMany(entity => entity.Vacancies, entity => entity.BillingType, 
                entity => entity.BillingTypeId);

            modelBuilder.Entity<Currency>().OneToMany(entity => entity.Salaries, entity => entity.Currency, 
                entity => entity.CurrencyId);

            modelBuilder.Entity<Department>().OneToMany(entity => entity.Vacancies, entity => entity.Department, 
                entity => entity.DepartmentId, false);

            modelBuilder.Entity<DriverLicenseType>().OneToMany(entity => entity.Vacancies, entity => entity.DriverLicenseType,
                entity => entity.DriverLicenseTypeId);

            modelBuilder.Entity<Employer>().OneToOne(entity => entity.Logo, entity => entity.Employer, 
                entity => entity.EmployerId);

            modelBuilder.Entity<Employer>().OneToOne(entity => entity.Description, entity => entity.Employer, 
                entity => entity.EmployerId);

            modelBuilder.Entity<Employer>().OneToOne(entity => entity.BrandedDescription, entity => entity.Employer, 
                entity => entity.EmployerId);

            modelBuilder.Entity<Employer>().OneToMany(entity => entity.Vacancies, entity => entity.Employer, 
                entity => entity.EmployerId);

            modelBuilder.Entity<Employer>().OneToMany(entity => entity.Industries, entity => entity.Employer, 
                entity => entity.EmployerId);

            modelBuilder.Entity<Employer>().OneToMany(entity => entity.InsiderInterviews, entity => entity.Employer, 
                entity => entity.EmployerId);

            modelBuilder.Entity<EmployerType>().OneToMany(entity => entity.Employers, entity => entity.Type, 
                entity => entity.TypeId);

            modelBuilder.Entity<Employment>().OneToMany(entity => entity.Vacancies, entity => entity.Employment, 
                entity => entity.EmploymentId);

            modelBuilder.Entity<Experience>().OneToMany(entity => entity.Vacancies, entity => entity.Experience, 
                entity => entity.ExperienceId);

            modelBuilder.Entity<Industry>().OneToMany(entity => entity.Children, entity => entity.Parent, 
                entity => entity.ParentId, false);

            modelBuilder.Entity<Industry>().OneToMany(entity => entity.Employers, entity => entity.Industry, 
                entity => entity.IndustryId);

            modelBuilder.Entity<InsiderInterview>().OneToMany(entity => entity.Vacancies, entity => entity.InsiderInterview, 
                entity => entity.InsiderInterviewId, false);

            modelBuilder.Entity<InsiderInterview>().OneToMany(entity => entity.Employers, entity => entity.InsiderInterview, 
                entity => entity.InsiderInterviewId);

            modelBuilder.Entity<KeySkill>().OneToMany(entity => entity.Vacancies, entity => entity.KeySkill, 
                entity => entity.KeySkillId);

            modelBuilder.Entity<Language>().OneToMany(entity => entity.Vacancies, entity => entity.Language, 
                entity => entity.LanguageId);

            modelBuilder.Entity<MetroLine>().OneToMany(entity => entity.Stations, entity => entity.Line, 
                entity => entity.MetroLineId);

            modelBuilder.Entity<Phone>().OneToMany(entity => entity.VacancyContacts, entity => entity.Phone, 
                entity => entity.PhoneId);

            modelBuilder.Entity<ProfessionalRole>().OneToMany(entity => entity.Vacancies, entity => entity.ProfessionalRole, 
                entity => entity.ProfessionalRoleId);

            modelBuilder.Entity<Schedule>().OneToMany(entity => entity.Vacancies, entity => entity.Schedule, 
                entity => entity.ScheduleId);

            modelBuilder.Entity<Specialization>().OneToMany(entity => entity.Children, entity => entity.Parent, 
                entity => entity.ParentId, false);

            modelBuilder.Entity<Specialization>().OneToMany(entity => entity.Vacancies, entity => entity.Specialization, 
                entity => entity.SpecializationId);

            modelBuilder.Entity<Entities.Vacancy>().OneToOne(entity => entity.Salary, entity => entity.Vacancy, 
                entity => entity.VacancyId);

            modelBuilder.Entity<Entities.Vacancy>().OneToOne(entity => entity.Contact, entity => entity.Vacancy, 
                entity => entity.VacancyId);

            modelBuilder.Entity<Entities.Vacancy>().OneToOne(entity => entity.Description, entity => entity.Vacancy, 
                entity => entity.VacancyId);

            modelBuilder.Entity<Entities.Vacancy>().OneToOne(entity => entity.BrandedDescription, entity => entity.Vacancy, 
                entity => entity.VacancyId);

            modelBuilder.Entity<Entities.Vacancy>().OneToMany(entity => entity.Languages, entity => entity.Vacancy, 
                entity => entity.VacancyId);

            modelBuilder.Entity<Entities.Vacancy>().OneToMany(entity => entity.KeySkills, entity => entity.Vacancy, 
                entity => entity.VacancyId);

            modelBuilder.Entity<Entities.Vacancy>().OneToMany(entity => entity.WorkingDays, entity => entity.Vacancy, 
                entity => entity.VacancyId);

            modelBuilder.Entity<Entities.Vacancy>().OneToMany(entity => entity.Specializations, entity => entity.Vacancy, 
                entity => entity.VacancyId);

            modelBuilder.Entity<Entities.Vacancy>().OneToMany(entity => entity.WorkingTimeModes, entity => entity.Vacancy, 
                entity => entity.VacancyId);

            modelBuilder.Entity<Entities.Vacancy>().OneToMany(entity => entity.ProfessionalRoles, entity => entity.Vacancy, 
                entity => entity.VacancyId);

            modelBuilder.Entity<Entities.Vacancy>().OneToMany(entity => entity.DriverLicenseTypes, entity => entity.Vacancy, 
                entity => entity.VacancyId);

            modelBuilder.Entity<Entities.Vacancy>().OneToMany(entity => entity.WorkingTimeIntervals, entity => entity.Vacancy, 
                entity => entity.VacancyId);

            modelBuilder.Entity<VacancyContact>().OneToMany(entity => entity.Phones, entity => entity.Contact, 
                entity => entity.ContactId);

            modelBuilder.Entity<VacancyType>().OneToMany(entity => entity.Vacancies, entity => entity.Type, 
                entity => entity.TypeId, false);

            modelBuilder.Entity<WorkingDay>().OneToMany(entity => entity.Vacancies, entity => entity.WorkingDay, 
                entity => entity.WorkingDayId);

            modelBuilder.Entity<WorkingTimeInterval>().OneToMany(entity => entity.Vacancies, entity => entity.WorkingTimeInterval, 
                entity => entity.WorkingTimeIntervalId);

            modelBuilder.Entity<WorkingTimeMode>().OneToMany(entity => entity.Vacancies, entity => entity.WorkingTimeMode, 
                entity => entity.WorkingTimeModeId);
        }
    }
}
