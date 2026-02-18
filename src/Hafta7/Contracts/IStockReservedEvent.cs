namespace Contracts;

public interface IStockReservedEvent
{
    Guid CorrelationId { get; }
    int OrderId { get; }
    int UserId { get; }
}
