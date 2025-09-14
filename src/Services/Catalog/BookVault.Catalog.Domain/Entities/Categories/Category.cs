using SharedKernel.Domain;

namespace BookVault.Catalog.Domain.Entities.Categories;

public class Category : Entity
{
    public string Name { get; set; } = null!;
}
