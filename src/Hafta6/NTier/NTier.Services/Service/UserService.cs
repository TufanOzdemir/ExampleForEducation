using Example1.Abstraction;
using NTier.Data.Abstraction;
using NTier.Data.Entities;

namespace Example1.Service;

public class UserService(IUserRepository userRepository) : IUserService
{
    public List<User> GetAll()
    {
        return userRepository.GetAll();
    }

    public User GetById(int id)
    {
        return userRepository.GetById(id);
    }
}
