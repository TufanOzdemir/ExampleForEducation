using BasketService.Domain.Entities;

namespace BasketService.Application.Interfaces
{
    public interface ITokenGenerator
    {
        string GenerateToken(User user);
    }
}
