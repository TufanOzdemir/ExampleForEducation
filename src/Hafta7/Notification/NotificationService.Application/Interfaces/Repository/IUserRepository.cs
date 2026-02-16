using NotificationService.Domain.Entities;

namespace NotificationService.Application.Interfaces.Repository
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User GetById(int id);
        User? GetByEmail(string email);
        void Add(User user);
    }
}
