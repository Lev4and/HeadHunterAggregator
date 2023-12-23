using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Reflection;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies
{
    public class VacanciesDbContextFactory : IDesignTimeDbContextFactory<VacanciesDbContext>
    {
        public VacanciesDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder();

            builder.UseNpgsql("", builder => builder.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName))
                .UseSnakeCaseNamingConvention();

            return new VacanciesDbContext(builder.Options);
        }
    }
}
