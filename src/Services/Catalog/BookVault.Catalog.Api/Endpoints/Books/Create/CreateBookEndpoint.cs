using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using BookVault.Catalog.Application.Features.Books.Commands.Create;
using BookVault.Catalog.Domain.Entities.Books;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Api.Endpoints;

namespace BookVault.Catalog.Api.Endpoints.Books.Create;

public sealed class CreateBookEndpoint : IEndpoint
{
    private sealed record CreateBookRequest(string Name, string Description);

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/books", async ([FromBody] CreateBookRequest request, ISender sender) =>
            {
                Result<Guid> result = await sender.Send(new CreateBookCommand(request.Name, request.Description));

                return result.ToMinimalApiResult();
            })
            .ProducesPost<Guid>()
            .WithTags(nameof(Book))
            .WithName(nameof(CreateBookEndpoint));
    }
}
