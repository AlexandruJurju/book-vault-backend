using SharedKernel.Api;
using SharedKernel.Application.CQRS.Queries;

namespace BookVault.Catalog.Application.Features.Books.Queries.List;

public record ListBookQuery(
    int Page,
    int PageSize,
    string? SearchTerm,
    string? OrderBy,
    bool? IsDescending
) : IQuery<PagedList<BookResponse>>;
