using MediatR;

namespace OrderService.Application.UseCases.Order.CancelOrder;

public record CancelOrderCommand(int OrderId) : IRequest<Unit>;
