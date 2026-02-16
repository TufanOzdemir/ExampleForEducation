using CleanArchitecture.Application.UseCases.Orders.Purchase;
using Example1.Abstraction;
using Example1.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Example1.Controllers
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
