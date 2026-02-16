using CleanArchitecture.Domain.Entities;

namespace Example1.Abstraction;

public interface IUserService
{
    List<User> GetAll();
    User GetById(int id);
}
