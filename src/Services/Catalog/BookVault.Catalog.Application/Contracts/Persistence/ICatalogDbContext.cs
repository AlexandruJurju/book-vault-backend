using BookVault.Catalog.Domain.Entities.Books;
using Microsoft.EntityFrameworkCore;

namespace BookVault.Catalog.Application.Contracts.Persistence;

public interface ICatalogDbContext
{
    DbSet<Book> Books { get; set; }
}
