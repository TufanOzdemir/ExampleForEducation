namespace Contracts;

public record StockReservedEvent(
    int OrderId,
    int UserId) : IStockReservedEvent;
