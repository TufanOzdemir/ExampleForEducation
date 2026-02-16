using IdentityService.Domain.Entities;

namespace IdentityService.Application.Interfaces
{
    public interface ITokenGenerator
    {
        string GenerateToken(User user);
    }
}
