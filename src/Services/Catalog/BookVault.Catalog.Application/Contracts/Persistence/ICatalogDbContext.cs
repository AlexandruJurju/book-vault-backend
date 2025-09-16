using BookVault.Catalog.Domain.Entities.Books;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Infrastructure.Persistence.Abstractions;

namespace BookVault.Catalog.Application.Contracts.Persistence;

public interface ICatalogDbContext
{
    DbSet<Book> Books { get; set; }
}
