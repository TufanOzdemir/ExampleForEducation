using ProductService.Domain.Entities;

namespace ProductService.Application.Interfaces
{
    public interface ITokenGenerator
    {
        string GenerateToken(User user);
    }
}
