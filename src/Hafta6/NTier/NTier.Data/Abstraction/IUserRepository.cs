using NTier.Data.Entities;

namespace NTier.Data.Abstraction
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User GetById(int id);
    }
}
