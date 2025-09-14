using Microsoft.EntityFrameworkCore;
using SharedKernel.Domain;

namespace SharedKernel.Infrastructure.Persistence.EntityFramework;

public static class QueryableExtensions
{
    public static IQueryable<T> ForTenant<T>(this DbSet<T> dbSet, Guid tenantId)
        where T : class, ITenantOwned
    {
        return dbSet.Where(t => t.TenantId == tenantId);
    }
}
