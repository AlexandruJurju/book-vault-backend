using BookVault.Catalog.Application.Abstractions.Data;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Infrastructure.Persistence.Abstractions;

namespace BookVault.Catalog.Infrastructure.Persistence;

public class CatalogDbContext : DbContext, IUnitOfWork, ICatalogDbContext
{
}
