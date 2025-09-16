using System.Linq.Expressions;
using Ardalis.Result;
using BookVault.Catalog.Application.Contracts.Persistence;
using BookVault.Catalog.Domain.Entities.Books;
using SharedKernel.Api;
using SharedKernel.Application.CQRS.Queries;

namespace BookVault.Catalog.Application.Features.Books.Queries.List;

public class ListBookQueryHandler(
    ICatalogDbContext dbContext
) : IQueryHandler<ListBookQuery, PagedList<BookResponse>>
{
    public async Task<Result<PagedList<BookResponse>>> Handle(ListBookQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Book> booksQuery = dbContext.Books;

        if (!string.IsNullOrEmpty(request.SearchTerm))
        {
            booksQuery = booksQuery.Where(b => b.Name.Contains(request.SearchTerm));
        }

        Expression<Func<Book, object>> keySelector = GetSortProperty(request);

        if (request.IsDescending is not null)
        {
            booksQuery = request.IsDescending.Value
                ? booksQuery.OrderByDescending(keySelector)
                : booksQuery.OrderBy(keySelector);
        }

        IQueryable<BookResponse> bookResponseQuery = booksQuery.Select(b => new BookResponse(b.Name, b.Description));

        var books = await PagedList<BookResponse>.CreateAsync(bookResponseQuery, request.Page, request.PageSize);

        return books;
    }

    private static Expression<Func<Book, object>> GetSortProperty(ListBookQuery request)
    {
        return request.OrderBy?.ToLowerInvariant() switch
        {
            "name" => b => b.Name,
            "description" => b => b.Description,
            _ => b => b.Id
        };
    }
}
