using FluentValidation;

namespace BookVault.Catalog.Application.Features.Books.Queries.List;

internal sealed class ListBookQueryValidator : AbstractValidator<ListBookQuery>
{
    public ListBookQueryValidator()
    {
        RuleFor(b => b.Page).GreaterThan(0);
        RuleFor(b => b.PageSize).GreaterThan(0);
    }
}
