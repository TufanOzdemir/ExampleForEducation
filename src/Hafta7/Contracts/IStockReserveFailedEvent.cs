namespace Contracts;

public interface IStockReserveFailedEvent
{
    Guid CorrelationId { get; }
    int OrderId { get; }
    int UserId { get; }
    IReadOnlyList<StockReserveFailedItem> Items { get; }
    string Reason { get; }
}
