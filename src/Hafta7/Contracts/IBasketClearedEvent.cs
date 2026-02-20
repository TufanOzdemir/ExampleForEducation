namespace Contracts;

public interface IBasketClearedEvent
{
    int OrderId { get; }
    int UserId { get; }
    IReadOnlyList<BasketClearedItem> Items { get; }
}
