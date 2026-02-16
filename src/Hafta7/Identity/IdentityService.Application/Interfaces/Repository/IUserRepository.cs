using IdentityService.Domain.Entities;

namespace IdentityService.Application.Interfaces.Repository
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User? GetById(int id);
        User? GetByEmail(string email);
        void Add(User user);
    }
}
