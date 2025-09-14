using SharedKernel.Domain;

namespace BookVault.Catalog.Domain.Entities.Authors;

public class Author : Entity
{
    public string Name { get; set; } = null!;
}
