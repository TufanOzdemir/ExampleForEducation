using BasketService.Application.Interfaces.Repository;
using BasketService.Domain.Entities;
using BasketService.Application.Abstraction;

namespace BasketService.Application.Services;

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
