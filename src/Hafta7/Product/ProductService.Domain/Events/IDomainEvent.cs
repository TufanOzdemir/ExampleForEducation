using MediatR;

namespace ProductService.Domain.Events;

/// <summary>
/// Domain'de gerçekleşen, MediatR ile publish edilip INotificationHandler ile işlenebilen olaylar.
/// </summary>
public interface IDomainEvent : INotification
{
    Guid EventId { get; }
    DateTime OccurredOnUtc { get; }
}
