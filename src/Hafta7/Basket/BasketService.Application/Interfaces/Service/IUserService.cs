using BasketService.Domain.Entities;

namespace BasketService.Application.Abstraction;

public interface IUserService
{
    List<User> GetAll();
    User GetById(int id);
}
