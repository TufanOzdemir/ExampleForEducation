namespace Contracts;

public record StockReservedEvent(
    Guid CorrelationId,
    int OrderId,
    int UserId) : IStockReservedEvent;
