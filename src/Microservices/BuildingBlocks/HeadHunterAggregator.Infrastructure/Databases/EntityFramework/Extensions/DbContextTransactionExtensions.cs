using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data.Common;

namespace HeadHunterAggregator.Infrastructure.Databases.EntityFramework.Extensions
{
    public static class DbContextTransactionExtensions
    {
        public static DbTransaction MapToDbTransaction(this IDbContextTransaction transaction)
        {
            return ((IInfrastructure<DbTransaction>)transaction).Instance;
        }
    }
}
