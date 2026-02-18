namespace Contracts;

public record OrderStartedFailedEvent(
    Guid CorrelationId,
    int OrderId,
    int UserId,
    string Reason) : IOrderStartedFailedEvent;
