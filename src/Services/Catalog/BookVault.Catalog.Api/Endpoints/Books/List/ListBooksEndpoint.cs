using Ardalis.Result;
using BookVault.Catalog.Application.Features.Books.Queries;
using BookVault.Catalog.Application.Features.Books.Queries.List;
using BookVault.Catalog.Domain.Entities.Books;
using MediatR;
using SharedKernel.Api;
using SharedKernel.Api.Endpoints;

namespace BookVault.Catalog.Api.Endpoints.Books.List;

public sealed class ListBooksEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/books", async (int page, int pageSize, string? searchTerm, string? orderBy, bool? isDescending, ISender sender, CancellationToken ct) =>
            {
                Result<PagedList<BookResponse>> result = await sender.Send(new ListBookQuery(page, pageSize, searchTerm, orderBy, isDescending), ct);

                return Results.Ok(result);
            })
            .Produces<PagedList<BookResponse>>()
            .WithTags(nameof(Book))
            .WithName(nameof(ListBooksEndpoint));
    }
}
