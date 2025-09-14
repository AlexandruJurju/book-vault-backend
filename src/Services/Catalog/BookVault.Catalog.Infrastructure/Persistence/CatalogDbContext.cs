using BookVault.Catalog.Application.Contracts.Persistence;
using BookVault.Catalog.Domain.Entities.Books;
using BookVault.Catalog.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Infrastructure.Persistence.Abstractions;

namespace BookVault.Catalog.Infrastructure.Persistence;

public class CatalogDbContext(DbContextOptions<CatalogDbContext> options) : DbContext(options), IUnitOfWork, ICatalogDbContext
{
    #region DbSets

    public DbSet<Book> Books { get; set; }

    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new BookConfiguration());
    }
}
