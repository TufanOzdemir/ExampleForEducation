namespace Contracts;

public record OrderStartedFailedEvent(
    int OrderId,
    int UserId,
    string Reason) : IOrderStartedFailedEvent;
