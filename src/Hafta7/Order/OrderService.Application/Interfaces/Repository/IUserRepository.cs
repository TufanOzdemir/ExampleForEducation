using OrderService.Domain.Entities;

namespace OrderService.Application.Interfaces.Repository;

public interface IUserRepository
{
    User? GetById(int id);
}
