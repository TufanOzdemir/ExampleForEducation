namespace Contracts;

public record StockReserveFailedEvent(
    int OrderId,
    int UserId,
    IReadOnlyList<StockReserveFailedItem> Items,
    string Reason) : IStockReserveFailedEvent;
