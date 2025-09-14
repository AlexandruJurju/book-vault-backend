using SharedKernel.Domain;

namespace BookVault.Catalog.Domain.Entities.Publishers;

public sealed class Publisher : Entity
{
    public string Name { get; set; } = null!;
}
