namespace Contracts;

public record StockReserveFailedEvent(
    Guid CorrelationId,
    int OrderId,
    int UserId,
    IReadOnlyList<StockReserveFailedItem> Items,
    string Reason) : IStockReserveFailedEvent;
