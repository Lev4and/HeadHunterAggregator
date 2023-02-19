using HeadHunter.EntityFramework.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HeadHunter.EntityFramework
{
    public static class Configure
    {
        public static void AddEntityFramework(this IServiceCollection services)
        {
            services.AddTransient<IEntityFrameworkRepository, HeadHunterRepository>();
            services.AddDbContext<HeadHunterDbContext>((options) =>
            {
                options
                    .UseNpgsql($"Host={PostgresConfiguration.Host};Port={PostgresConfiguration.Port};" +
                        $"Database={PostgresConfiguration.DatabaseName};Username={PostgresConfiguration.Username};" +
                        $"Password={PostgresConfiguration.Password};Integrated Security=true;Pooling=true;")
                    .UseSnakeCaseNamingConvention();
            });
        }
    }
}
