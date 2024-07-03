using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace JWT.Api.Jwt
{
    public class JwtProvider
    {
        public string CreateToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySecretKey123 MySecretKey123 MySecretKey123" +
                " MySecretKey123 MySecretKey123 MySecretKey123"));
            JwtSecurityToken securityToken = new(
                issuer:"Rashad",
                audience:"SalamAleykum",
                signingCredentials:new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha512));
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(securityToken);
        }
    }
}
