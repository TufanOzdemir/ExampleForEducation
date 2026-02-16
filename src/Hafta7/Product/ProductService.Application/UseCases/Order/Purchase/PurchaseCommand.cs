using MediatR;

namespace ProductService.Application.UseCases.Orders.Purchase;

/// <summary>
/// Sepetteki ürünlerle sipariş oluşturma (MediatR command).
/// </summary>
public record PurchaseCommand() : IRequest<Unit>;
