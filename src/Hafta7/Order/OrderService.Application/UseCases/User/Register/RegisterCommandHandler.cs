using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Interfaces.Repository;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.UseCases.Users.Login;

public sealed class RegisterCommandHandler(IUnitOfWork unitOfWork, IPasswordHasher passwordHasher) : IRequestHandler<RegisterCommand, Unit>
{
    public Task<Unit> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        User user = new()
        {
            Name = request.register.Name,
            Email = request.register.Email,
            Phone = request.register.Phone
        };

        user.PasswordHash = passwordHasher.HashPassword(request.register.Password);

        unitOfWork.Users.Add(user);
        unitOfWork.SaveChanges();

        return Unit.Task;
    }
}
