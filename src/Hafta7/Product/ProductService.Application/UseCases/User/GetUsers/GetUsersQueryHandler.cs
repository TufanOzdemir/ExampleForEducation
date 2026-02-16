using ProductService.Application.Interfaces.Repository;
using ProductService.Domain.Entities;
using MediatR;

namespace ProductService.Application.UseCases.Users.GetUsers;

public sealed class GetUsersQueryHandler(IUserRepository unitOfWork) : IRequestHandler<GetUsersQuery, List<User>>
{
    public Task<List<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var users = unitOfWork.GetAll();
        return Task.FromResult(users);
    }
}
