using HeadHunter.Database.PostgreSQL.Common;
using HeadHunter.Database.PostgreSQL.Entities;
using Microsoft.EntityFrameworkCore;

namespace HeadHunter.Database.PostgreSQL
{
    public class HeadHunterDbContext : PostgreSqlDbContext
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

        public DbSet<Vacancy> Vacancies { get; set; }

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

        public HeadHunterDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseNpgsql("Server=lev4and.ru;Database=HeadHunter;User Id=postgres;Password=sa;" +
                        "Integrated Security=true;Pooling=true;", builder => builder.MigrationsAssembly("HeadHunter.ResourceWebApplication"))
                    .UseSnakeCaseNamingConvention();
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.FillDefaultData();
            builder.BindModels();
        }
    }
}
