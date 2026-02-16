using MediatR;
using ProductService.Application.Interfaces.Repository;
using ProductEntity = ProductService.Domain.Entities.Product;

namespace ProductService.Application.UseCases.Product.GetProductById;

public sealed class GetProductByIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetProductByIdQuery, ProductEntity?>
{
    public Task<ProductEntity?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = unitOfWork.Products.GetById(request.Id);
        return Task.FromResult(product);
    }
}
