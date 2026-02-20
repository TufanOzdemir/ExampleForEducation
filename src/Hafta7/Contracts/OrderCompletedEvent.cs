namespace Contracts;

public record OrderCompletedEvent(
    int OrderId,
    int UserId,
    decimal TotalPrice) : IOrderCompletedEvent;
