using CleanArchitecture.Application.UseCases.Basket.AddToBasketUseCaseOld;
using Example1.Abstraction;
using Example1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Example1.Controllers
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
