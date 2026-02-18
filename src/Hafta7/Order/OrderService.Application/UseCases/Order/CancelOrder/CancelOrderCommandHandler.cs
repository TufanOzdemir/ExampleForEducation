using MediatR;
using OrderService.Application.Interfaces.Repository;

namespace OrderService.Application.UseCases.Order.CancelOrder;

public sealed class CancelOrderCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CancelOrderCommand, Unit>
{
    public Task<Unit> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
    {
        var order = unitOfWork.Orders.GetById(request.OrderId);
        if (order == null)
        {
            return Task.FromResult(Unit.Value);
        }

        order.MarkCancelled();
        unitOfWork.SaveChanges();

        return Task.FromResult(Unit.Value);
    }
}
