using ProductService.Domain.Entities;

namespace ProductService.Application.Abstraction;

public interface IUserService
{
    List<User> GetAll();
    User GetById(int id);
}
