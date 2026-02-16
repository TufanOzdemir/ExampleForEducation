using IdentityService.Application.UseCases.Orders.Purchase;
using IdentityService.Application.Abstraction;
using IdentityService.Api.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityService.Api.Controllers
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
