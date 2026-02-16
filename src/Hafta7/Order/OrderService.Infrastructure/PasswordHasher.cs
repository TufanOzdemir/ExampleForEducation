using CleanArchitecture.Application.Interfaces;

namespace CleanArchitecture.Infrastructure
{
    internal class PasswordHasher : IPasswordHasher
    {

        private const int WorkFactor = 12;

        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, WorkFactor);
        }

        public bool VerifyPassword(string? hashedPassword, string providedPassword)
        {
            if (string.IsNullOrEmpty(hashedPassword) || string.IsNullOrEmpty(providedPassword))
                return false;
            try
            {
                return BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword);
            }
            catch
            {
                return false;
            }
        }
    }
}
