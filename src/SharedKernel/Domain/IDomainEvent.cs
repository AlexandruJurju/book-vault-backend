using MediatR;
using SharedKernel.Infrastructure.Helpers;

namespace SharedKernel.Domain;

public interface IDomainEvent : INotification
{
    DateTime OccurredOnUtc => DateTimeHelper.UtcNow();
}
