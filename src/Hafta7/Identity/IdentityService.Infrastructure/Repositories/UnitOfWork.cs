using IdentityService.Application.Interfaces.Repository;

namespace IdentityService.Infrastructure.Repositories;

internal class UnitOfWork(IdentityDbContext context, IUserRepository userRepository) : IUnitOfWork
{
    public IUserRepository Users => userRepository;

    public int SaveChanges() => context.SaveChanges();
}
