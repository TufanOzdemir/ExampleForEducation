using NotificationService.Application.Interfaces;
using NotificationService.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NotificationService.Infrastructure
{
    internal class JWTTokenGenerator(IConfiguration _configuration) : ITokenGenerator
    {
        public string GenerateToken(User user)
        {
            // 1. Temel Claim'ler (Identity)
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, user.Name),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            // 2. Permission'ları Role claim olarak ekleme
            // [Authorize(Roles = "GetAll_User")] gibi attribute'lar ClaimTypes.Role claim'ine bakar.
            // "permission" yerine Role claim kullanılmazsa 403 Forbidden döner.
            foreach (var permission in user.Permissions)
            {
                claims.Add(new Claim(ClaimTypes.Role, permission.Name));
            }

            // 3. Güvenlik Anahtarı ve İmzalama
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // 4. Token Ayarları
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
