using SharedKernel.Application.CQRS.Commands;

namespace BookVault.Catalog.Application.Features.Books.Commands.Create;

public record CreateBookCommand(string Name, string Description) : ICommand<Guid>;
