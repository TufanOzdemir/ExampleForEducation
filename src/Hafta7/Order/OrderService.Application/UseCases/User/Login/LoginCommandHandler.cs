using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Interfaces.Repository;
using MediatR;

namespace CleanArchitecture.Application.UseCases.Users.Login;

public sealed class LoginCommandHandler(IUnitOfWork unitOfWork, ITokenGenerator tokenGenerator, IPasswordHasher passwordHasher) : IRequestHandler<LoginCommand, string>
{
    public Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = unitOfWork.Users.GetByEmail(request.Email);

        if (user == null)
        {
            throw new Exception("User not found");
        }

        if (!passwordHasher.VerifyPassword(user.PasswordHash, request.Password))
        {
            throw new Exception("Invalid password");
        }

        var result = tokenGenerator.GenerateToken(user);

        return Task.FromResult(result);
    }
}
