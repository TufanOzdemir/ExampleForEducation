using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Interfaces.Repository
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User GetById(int id);
        User? GetByEmail(string email);
        void Add(User user);
    }
}
