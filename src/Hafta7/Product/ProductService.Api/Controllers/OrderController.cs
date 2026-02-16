using ProductService.Application.UseCases.Orders.Purchase;
using ProductService.Application.Abstraction;
using ProductService.Api.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(IMediator mediator) : ControllerBase
    {
        [HttpPost("Purchase")]
        [Authorize]
        public IActionResult Purchase([FromBody] PurchaseRequest request)
        {
            mediator.Send(new PurchaseCommand());
            return Ok("Purchase successful");
        }
    }
}
