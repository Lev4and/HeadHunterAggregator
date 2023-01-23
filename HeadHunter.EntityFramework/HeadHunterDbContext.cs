using HeadHunter.EntityFramework.Core;
using Microsoft.EntityFrameworkCore;

namespace HeadHunter.EntityFramework
{
    public class HeadHunterDbContext : AppDbContextBase
    {
        public HeadHunterDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
