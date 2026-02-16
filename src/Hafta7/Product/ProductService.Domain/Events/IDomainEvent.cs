namespace ProductService.Domain.Events;

/// <summary>
/// Domain'de gerçekleşen olaylar için marker arayüz.
/// </summary>
public interface IDomainEvent
{
    Guid EventId { get; }
    DateTime OccurredOnUtc { get; }
}
