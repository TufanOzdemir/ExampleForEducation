namespace IdentityService.Application.Interfaces.Repository;

public interface IUnitOfWork
{
    IUserRepository Users { get; }
    int SaveChanges();
}
