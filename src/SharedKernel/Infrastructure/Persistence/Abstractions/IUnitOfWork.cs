using System.Data.Common;

namespace SharedKernel.Infrastructure.Persistence.Abstractions;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
