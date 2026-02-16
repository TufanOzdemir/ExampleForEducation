using MediatR;
using ProductService.Application.Interfaces.Repository;
using ProductEntity = ProductService.Domain.Entities.Product;

namespace ProductService.Application.UseCases.Product.GetProducts;

public sealed class GetProductsQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetProductsQuery, List<ProductEntity>>
{
    public Task<List<ProductEntity>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = unitOfWork.Products.GetAll();
        return Task.FromResult(products);
    }
}
