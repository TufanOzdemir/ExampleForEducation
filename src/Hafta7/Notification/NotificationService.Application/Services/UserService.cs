using NotificationService.Application.Interfaces.Repository;
using NotificationService.Domain.Entities;
using NotificationService.Application.Abstraction;

namespace NotificationService.Application.Services;

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
