using MediatR;
using ProductEntity = ProductService.Domain.Entities.Product;

namespace ProductService.Application.UseCases.Product.GetProducts;

public record GetProductsQuery : IRequest<List<ProductEntity>>;
