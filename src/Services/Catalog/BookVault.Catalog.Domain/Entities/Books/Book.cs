using SharedKernel.Domain;

namespace BookVault.Catalog.Domain.Entities.Books;

public sealed class Book : AuditableEntity, ISoftDeletable
{
    private Book()
    {
    }

    private Book(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public static Book Create(string name, string description)
    {
        var book = new Book(name, description);

        return book;
    }

    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public bool IsDeleted { get; set; }
}
