using CleanArchitecture.Application.Interfaces.Repository;
using CleanArchitecture.Domain.Entities;
using Example1.Abstraction;

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
