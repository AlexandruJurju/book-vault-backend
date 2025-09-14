using BookVault.Catalog.Infrastructure.Persistence;
using SharedKernel.Infrastructure.Persistence.EntityFramework;

namespace BookVault.Catalog.Infrastructure;

public class CatalogDbContextSeeder : IDbSeeder<CatalogDbContext>
{
    public Task SeedAsync(CatalogDbContext context)
    {
        throw new NotImplementedException();
    }
}
