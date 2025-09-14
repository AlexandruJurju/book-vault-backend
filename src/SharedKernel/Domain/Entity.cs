namespace SharedKernel.Domain;

public abstract class Entity : HasDomainEventsBase
{
    public Guid Id { get; set; } = Guid.NewGuid();
}

public abstract class Entity<TId> : Entity
    where TId : IEquatable<TId>
{
    public new TId Id { get; set; } = default!;
}
