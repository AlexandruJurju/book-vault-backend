namespace SharedKernel.Domain;

public interface ISoftDeletable
{
    bool IsDeleted { get; set; }
}
