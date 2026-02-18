namespace Contracts;

public record BasketClearedEvent(
    Guid CorrelationId,
    int OrderId,
    int UserId,
    IReadOnlyList<BasketClearedItem> Items) : IBasketClearedEvent;
