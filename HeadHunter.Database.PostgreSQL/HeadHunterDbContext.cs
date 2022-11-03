using HeadHunter.Database.PostgreSQL.Common;
using Microsoft.EntityFrameworkCore;

namespace HeadHunter.Database.PostgreSQL
{
    public class HeadHunterDbContext : PostgreSqlDbContext
    {
        public HeadHunterDbContext(DbContextOptions<PostgreSqlDbContext> options) : base(options)
        {

        }
    }
}
