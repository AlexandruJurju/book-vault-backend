using BookVault.Catalog.Domain.Entities.Authors;
using SharedKernel.Domain;

namespace BookVault.Catalog.Domain.Entities.Books;

public sealed class Book : AuditableEntity, ISoftDeletable
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public Money Price { get; set; }
    public int TotalReviews { get; set; }
    public double AverageRating { get; set; }
    private readonly List<Author> _authors = new();
    public IReadOnlyCollection<Author> Authors => _authors.AsReadOnly();
    public bool IsDeleted { get; set; }
}
