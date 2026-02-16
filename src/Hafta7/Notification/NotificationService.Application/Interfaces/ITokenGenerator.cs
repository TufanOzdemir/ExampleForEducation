using NotificationService.Domain.Entities;

namespace NotificationService.Application.Interfaces
{
    public interface ITokenGenerator
    {
        string GenerateToken(User user);
    }
}
