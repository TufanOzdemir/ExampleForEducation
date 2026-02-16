using IdentityService.Application.UseCases.Basket.AddToBasketUseCaseOld;
using IdentityService.Application.Abstraction;
using IdentityService.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController(AddToBasketCommandHandler addToBasketCommandHandler) : ControllerBase
    {
        [HttpPost("AddToBasket")]
        [Authorize]
        public IActionResult AddToBasket([FromBody] AddToBasketRequest request)
        {
            addToBasketCommandHandler.Execute(new AddToBasketCommand(request.ProductId));
            return Ok("Product added to basket");
        }
    }
}
