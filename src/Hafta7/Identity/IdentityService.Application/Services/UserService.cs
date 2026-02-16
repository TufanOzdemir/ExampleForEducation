using IdentityService.Application.Interfaces.Repository;
using IdentityService.Domain.Entities;
using IdentityService.Application.Abstraction;

namespace IdentityService.Application.Services;

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
