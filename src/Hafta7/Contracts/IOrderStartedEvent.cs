namespace Contracts;

public interface IOrderStartedEvent
{
    Guid CorrelationId { get; }
    int OrderId { get; }
    int UserId { get; }
    decimal TotalPrice { get; }
    IReadOnlyList<OrderStartedItem> Items { get; }
}
