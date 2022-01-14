using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api.MiniEcommerce.Auth
{
    public class Jwt
    {
        private readonly JwtConfiguration _jwtConfiguration;

        public Jwt(JwtConfiguration jwtConfiguration)
        {
            _jwtConfiguration = jwtConfiguration ??
                throw new ArgumentNullException(nameof(jwtConfiguration));
        }

        public Token GerarToken(string email, string role, string name)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtConfiguration.Key);

            var dateExpiration = DateTime.UtcNow.AddMinutes(10);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, email),
                    new Claim(ClaimTypes.Role, role)
                }),
                Expires = dateExpiration,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new Token
            {
                Name = name,
                Key = tokenHandler.WriteToken(token),
                DateExpiration = dateExpiration
            };
        }
    }
}
