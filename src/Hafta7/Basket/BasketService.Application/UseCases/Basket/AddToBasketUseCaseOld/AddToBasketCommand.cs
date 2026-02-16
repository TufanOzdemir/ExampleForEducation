using MediatR;

namespace BasketService.Application.UseCases.Basket.AddToBasketUseCaseOld;

public record AddToBasketCommand(int ProductId) : IRequest<Unit>;
