using BookVault.AspireConstants;
using BookVault.Catalog.Application.Contracts.Persistence;
using BookVault.Catalog.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SharedKernel.Infrastructure.Persistence.EntityFramework;

namespace BookVault.Catalog.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(
        this IHostApplicationBuilder builder)
    {
        IServiceCollection services = builder.Services;

        builder.AddDefaultPostgresDb<CatalogDbContext>(
            Components.Databases.Catalog,
            _ => services.AddMigration<CatalogDbContext>());

        services.AddScoped<ICatalogDbContext>(sp => sp.GetRequiredService<CatalogDbContext>());
    }
}
