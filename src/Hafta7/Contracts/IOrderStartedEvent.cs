namespace Contracts;

public interface IOrderStartedEvent
{
    int OrderId { get; }
    int UserId { get; }
    decimal TotalPrice { get; }
    IReadOnlyList<OrderStartedItem> Items { get; }
}
