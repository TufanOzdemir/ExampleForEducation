using CleanArchitecture.Application.Interfaces.Repository;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.UseCases.Users.GetUserById;

public sealed class GetUserByIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetUserByIdQuery, User>
{
    public Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = unitOfWork.Users.GetById(request.Id);
        return Task.FromResult(user);
    }
}
