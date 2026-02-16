using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductService.Application.UseCases.Product.GetProductById;
using ProductService.Application.UseCases.Product.GetProducts;

namespace ProductService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetProducts(CancellationToken cancellationToken)
    {
        var products = await mediator.Send(new GetProductsQuery(), cancellationToken);
        return Ok(products);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetProductById(int id, CancellationToken cancellationToken)
    {
        var product = await mediator.Send(new GetProductByIdQuery(id), cancellationToken);
        if (product == null)
            return NotFound();
        return Ok(product);
    }
}
