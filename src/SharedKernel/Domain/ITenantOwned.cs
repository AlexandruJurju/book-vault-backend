namespace SharedKernel.Domain;

public interface ITenantOwned
{
    Guid TenantId { get; set; }
}
