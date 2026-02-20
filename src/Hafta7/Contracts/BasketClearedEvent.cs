namespace Contracts;

public record BasketClearedEvent(
    int OrderId,
    int UserId,
    IReadOnlyList<BasketClearedItem> Items) : IBasketClearedEvent;
