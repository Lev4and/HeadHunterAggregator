using System.Data.Common;

namespace HeadHunterAggregator.Domain.Infrastructure.Databases
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        Task<DbTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);

        Task CommitTransactionAsync(CancellationToken cancellationToken = default);
    }
}
