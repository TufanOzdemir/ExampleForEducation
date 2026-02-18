namespace Contracts;

public interface IBasketClearedEvent
{
    Guid CorrelationId { get; }
    int OrderId { get; }
    int UserId { get; }
    IReadOnlyList<BasketClearedItem> Items { get; }
}
