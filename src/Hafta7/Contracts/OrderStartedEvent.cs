namespace Contracts;

public record OrderStartedEvent(
    int OrderId,
    int UserId,
    decimal TotalPrice,
    IReadOnlyList<OrderStartedItem> Items) : IOrderStartedEvent;
