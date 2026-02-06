using Example1.Models;

namespace Example1.Abstraction;

public interface IUserService
{
    List<User> GetAll();
    User GetById(int id);
}
