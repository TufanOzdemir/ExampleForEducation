using BasketService.Domain.Entities;

namespace BasketService.Application.Interfaces.Repository
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User GetById(int id);
        User? GetByEmail(string email);
        void Add(User user);
    }
}
