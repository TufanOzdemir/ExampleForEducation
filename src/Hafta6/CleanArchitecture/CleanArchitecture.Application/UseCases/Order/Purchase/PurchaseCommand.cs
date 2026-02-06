using MediatR;

namespace CleanArchitecture.Application.UseCases.Orders.Purchase;

/// <summary>
/// Sepetteki ürünlerle sipariş oluşturma (MediatR command).
/// </summary>
public record PurchaseCommand() : IRequest<Unit>;
