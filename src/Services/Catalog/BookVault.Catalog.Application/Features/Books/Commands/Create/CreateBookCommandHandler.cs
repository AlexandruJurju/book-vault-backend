using Ardalis.Result;
using BookVault.Catalog.Application.Contracts.Persistence;
using BookVault.Catalog.Domain.Entities.Books;
using SharedKernel.Application.CQRS.Commands;
using SharedKernel.Infrastructure.Persistence.Abstractions;

namespace BookVault.Catalog.Application.Features.Books.Commands.Create;

public class CreateBookCommandHandler(
    ICatalogDbContext dbContext,
    IUnitOfWork unitOfWork
) : ICommandHandler<CreateBookCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var book = Book.Create(request.Name, request.Description);

        dbContext.Books.Add(book);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return book.Id;
    }
}
