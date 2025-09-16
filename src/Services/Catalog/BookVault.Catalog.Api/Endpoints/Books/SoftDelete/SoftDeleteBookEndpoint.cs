using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using BookVault.Catalog.Application.Features.Books.Commands.SoftDelete;
using BookVault.Catalog.Domain.Entities.Books;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Api.Endpoints;

namespace BookVault.Catalog.Api.Endpoints.Books.SoftDelete;

public class SoftDeleteBookEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("/books/{id:guid}", async ([FromRoute] Guid id, ISender sender, CancellationToken ct) =>
            {
                Result result = await sender.Send(new SoftDeleteBookCommand(id), ct);

                return result.ToMinimalApiResult();
            })
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithTags(nameof(Book))
            .WithName(nameof(SoftDeleteBookEndpoint));
    }
}
