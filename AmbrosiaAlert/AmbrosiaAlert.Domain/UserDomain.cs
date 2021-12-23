using AmbrosiaAlert.Shared.Models;
using AmbrosiaAlert.Shared.Settings;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AmbrosiaAlert.Domain
{
    public static class UserDomain
    {
        public static string HashPassword(string pass, PassSettings settings)
        {
            using var algorithm = new Rfc2898DeriveBytes(
                pass, settings.SaltSize, settings.Iterations, HashAlgorithmName.SHA256);
            var key = Convert.ToBase64String(algorithm.GetBytes(settings.KeySize));
            var salt = Convert.ToBase64String(algorithm.Salt);
            var result = $"{settings.Iterations}.{salt}.{key}";
            return result;
        }

        public static bool CheckPassword(string pass, string hash, PassSettings settings)
        {
            var parts = hash.Split('.');
            var salt = Convert.FromBase64String(parts[1]);
            var key = parts[2];
            using var algorithm = new Rfc2898DeriveBytes(
                pass, salt, settings.Iterations, HashAlgorithmName.SHA256);
            var passKey = Convert.ToBase64String(algorithm.GetBytes(settings.KeySize));
            var result = passKey.Equals(key);
            return result;
        }

        public static string GetAccessToken(User user, string secret)
        {
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var handler = new JwtSecurityTokenHandler();
            var roles = user.IsAdmin ? new Claim[] { new Claim(ClaimTypes.Role, "Admin") } : Enumerable.Empty<Claim>();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = creds,
                Expires = DateTime.UtcNow.AddDays(7),
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, "User")
                }.Concat(roles)),
            };
            var token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);
        }

        public static User CreateUser(string username, string email, string hashedPass, bool isAdmin)
        {
            var user = new User()
            {
                Username = username,
                Email = email,
                Password = hashedPass,
                IsAdmin = isAdmin,
                RegisteredAt = DateTime.Now
            };

            return user;
        }
    }
}
