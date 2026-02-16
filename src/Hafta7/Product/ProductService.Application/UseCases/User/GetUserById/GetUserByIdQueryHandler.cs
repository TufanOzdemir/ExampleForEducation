using ProductService.Application.Interfaces.Repository;
using ProductService.Domain.Entities;
using MediatR;

namespace ProductService.Application.UseCases.Users.GetUserById;

public sealed class GetUserByIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetUserByIdQuery, User>
{
    public Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = unitOfWork.Users.GetById(request.Id);
        return Task.FromResult(user);
    }
}
