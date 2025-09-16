using Ardalis.Result;
using BookVault.Catalog.Application.Contracts.Persistence;
using BookVault.Catalog.Domain.Entities.Books;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Application.CQRS.Commands;
using SharedKernel.Infrastructure.Persistence.Abstractions;

namespace BookVault.Catalog.Application.Features.Books.Commands.SoftDelete;

public class SoftDeleteBookCommandHandler(
    ICatalogDbContext dbContext,
    IUnitOfWork unitOfWork
) : ICommandHandler<SoftDeleteBookCommand>
{
    public async Task<Result> Handle(SoftDeleteBookCommand request, CancellationToken cancellationToken)
    {
        Book? book = await dbContext.Books.SingleOrDefaultAsync(x => x.Id == request.BookId, cancellationToken);

        if (book is null)
        {
            return Result.NotFound();
        }

        book.IsDeleted = true;

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
