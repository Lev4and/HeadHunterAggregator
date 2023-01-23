using HeadHunter.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace HeadHunter.ResourceWebApplication.Extensions
{
    public static class EntityFrameworkExtensions
    {
        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder builder)
        {
            using (var scope = builder.ApplicationServices.CreateScope())
            {
                using (var context = scope.ServiceProvider.GetRequiredService<HeadHunterDbContext>())
                {
                    context.Database.Migrate();
                }
            }

            return builder;
        }
    }
}
