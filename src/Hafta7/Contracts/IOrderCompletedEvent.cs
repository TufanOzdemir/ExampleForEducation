namespace Contracts;

public interface IOrderCompletedEvent
{
    int OrderId { get; }
    int UserId { get; }
    decimal TotalPrice { get; }
}
