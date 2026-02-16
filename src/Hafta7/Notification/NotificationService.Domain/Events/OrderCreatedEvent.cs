namespace NotificationService.Domain.Events;

/// <summary>
/// Sipariş oluşturulduğunda yayımlanır.
/// </summary>
public sealed record OrderCreatedEvent(int OrderId, int UserId, decimal TotalPrice)
    : DomainEventBase;
