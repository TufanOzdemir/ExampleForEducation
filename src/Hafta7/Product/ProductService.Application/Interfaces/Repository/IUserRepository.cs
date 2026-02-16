using ProductService.Domain.Entities;

namespace ProductService.Application.Interfaces.Repository
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User GetById(int id);
        User? GetByEmail(string email);
        void Add(User user);
    }
}
