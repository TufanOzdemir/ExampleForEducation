namespace Contracts;

public interface IStockReserveFailedEvent
{
    int OrderId { get; }
    int UserId { get; }
    IReadOnlyList<StockReserveFailedItem> Items { get; }
    string Reason { get; }
}
