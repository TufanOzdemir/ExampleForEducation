using Example1.Abstraction;
using Example1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Example1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(IOrderService orderService) : ControllerBase
    {
        [HttpPost("Purchase")]
        public IActionResult Purchase([FromBody] PurchaseRequest request)
        {
            orderService.Purchase(request.UserId);
            return Ok("Purchase successful");
        }
    }
}
