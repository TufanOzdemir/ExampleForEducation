using BasketService.Application.UseCases.Basket.AddToBasketUseCaseOld;
using BasketService.Api.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BasketService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController(IMediator mediator) : ControllerBase
    {
        [HttpPost("AddToBasket")]
        [Authorize]
        public async Task<IActionResult> AddToBasket([FromBody] AddToBasketRequest request, CancellationToken cancellationToken)
        {
            await mediator.Send(new AddToBasketCommand(request.ProductId), cancellationToken);
            return Ok("Product added to basket");
        }
    }
}
