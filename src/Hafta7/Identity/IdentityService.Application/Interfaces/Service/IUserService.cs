using IdentityService.Domain.Entities;

namespace IdentityService.Application.Abstraction;

public interface IUserService
{
    List<User> GetAll();
    User GetById(int id);
}
