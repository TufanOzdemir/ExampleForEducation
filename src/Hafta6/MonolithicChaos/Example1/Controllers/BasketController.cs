using Example1.Abstraction;
using Example1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Example1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController(IBasketService basketService) : ControllerBase
    {
        [HttpPost("AddToBasket")]
        public IActionResult AddToBasket([FromBody] AddToBasketRequest request)
        {
            basketService.AddToBasket(request.UserId, request.ProductId);
            return Ok("Product added to basket");
        }
    }
}
