using MediatR;
using ProductEntity = ProductService.Domain.Entities.Product;

namespace ProductService.Application.UseCases.Product.GetProductById;

public record GetProductByIdQuery(int Id) : IRequest<ProductEntity?>;
