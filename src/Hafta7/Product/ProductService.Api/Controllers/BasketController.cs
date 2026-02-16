using ProductService.Application.UseCases.Basket.AddToBasketUseCaseOld;
using ProductService.Application.Abstraction;
using ProductService.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductService.Api.Controllers
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
