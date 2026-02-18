namespace Contracts;

public interface IOrderCompletedEvent
{
    Guid CorrelationId { get; }
    int OrderId { get; }
    int UserId { get; }
    decimal TotalPrice { get; }
}
