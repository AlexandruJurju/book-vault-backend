using SharedKernel.Application.CQRS.Commands;

namespace BookVault.Catalog.Application.Features.Books.Commands.SoftDelete;

public record SoftDeleteBookCommand(Guid BookId) : ICommand;
