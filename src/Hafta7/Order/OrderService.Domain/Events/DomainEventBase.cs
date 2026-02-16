namespace CleanArchitecture.Domain.Events;

/// <summary>
/// Domain event'leri için temel sınıf. EventId ve OccurredOnUtc otomatik atanır.
/// </summary>
public abstract record DomainEventBase : IDomainEvent
{
    public Guid EventId { get; } = Guid.NewGuid();
    public DateTime OccurredOnUtc { get; } = DateTime.UtcNow;
}
