using IdentityService.Application.Interfaces.Repository;
using IdentityService.Domain.Entities;
using MediatR;

namespace IdentityService.Application.UseCases.Users.GetUserById;

public sealed class GetUserByIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetUserByIdQuery, User>
{
    public Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = unitOfWork.Users.GetById(request.Id);
        return Task.FromResult(user);
    }
}
