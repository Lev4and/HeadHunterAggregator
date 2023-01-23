using HeadHunter.Core.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HeadHunter.EntityFramework
{
    public static class Configure
    {
        public static void AddEntityFramework(this IServiceCollection services)
        {
            services.AddTransient<IRepository, HeadHunterRepository>();
            services.AddDbContext<HeadHunterDbContext>((options) =>
            {
                options
                    .UseNpgsql($"Host={Environment.GetEnvironmentVariable("POSTGRES_SERVER")};" +
                        $"Port={Environment.GetEnvironmentVariable("POSTGRES_PORT")};" +
                        $"Database={Environment.GetEnvironmentVariable("POSTGRES_DB_NAME")};" +
                        $"Username={Environment.GetEnvironmentVariable("POSTGRES_USER")};" +
                        $"Password={Environment.GetEnvironmentVariable("POSTGRES_PASSWORD")};" +
                        "Integrated Security=true;Pooling=true;")
                    .UseSnakeCaseNamingConvention();
            });
        }
    }
}
