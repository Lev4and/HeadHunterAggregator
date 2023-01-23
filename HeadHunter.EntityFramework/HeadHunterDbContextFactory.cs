using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HeadHunter.EntityFramework
{
    public class HeadHunterDbContextFactory : IDesignTimeDbContextFactory<HeadHunterDbContext>
    {
        public HeadHunterDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder();

            builder.UseNpgsql("", builder => builder.MigrationsAssembly("HeadHunter.EntityFramework"));
            builder.UseSnakeCaseNamingConvention();

            return new HeadHunterDbContext(builder.Options);
        }
    }
}
