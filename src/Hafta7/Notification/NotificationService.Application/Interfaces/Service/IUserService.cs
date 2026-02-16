using NotificationService.Domain.Entities;

namespace NotificationService.Application.Abstraction;

public interface IUserService
{
    List<User> GetAll();
    User GetById(int id);
}
