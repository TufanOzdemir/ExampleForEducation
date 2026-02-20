namespace Contracts;

public interface IStockReservedEvent
{
    int OrderId { get; }
    int UserId { get; }
}
