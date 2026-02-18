namespace Contracts;

public record OrderCompletedEvent(
    Guid CorrelationId,
    int OrderId,
    int UserId,
    decimal TotalPrice) : IOrderCompletedEvent;
