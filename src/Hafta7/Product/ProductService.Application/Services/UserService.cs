using ProductService.Application.Interfaces.Repository;
using ProductService.Domain.Entities;
using ProductService.Application.Abstraction;

namespace ProductService.Application.Services;

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
