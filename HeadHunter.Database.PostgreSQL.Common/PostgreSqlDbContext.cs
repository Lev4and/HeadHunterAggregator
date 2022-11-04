using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace HeadHunter.Database.PostgreSQL.Common
{
    public class PostgreSqlDbContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
    {
        private readonly PostgresCompiler _compiler;
        private readonly NpgsqlConnection _connection;

        public QueryFactory QueryFactory { get; }

        public PostgreSqlDbContext(DbContextOptions options) : base(options)
        {
            _compiler = new PostgresCompiler();
            _connection = new NpgsqlConnection(Database.GetConnectionString());

            QueryFactory = new QueryFactory(_connection, _compiler);
        }
    }
}
