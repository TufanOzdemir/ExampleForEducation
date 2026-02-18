namespace Contracts;

public record OrderStartedEvent(
    Guid CorrelationId,
    int OrderId,
    int UserId,
    decimal TotalPrice,
    IReadOnlyList<OrderStartedItem> Items) : IOrderStartedEvent;
