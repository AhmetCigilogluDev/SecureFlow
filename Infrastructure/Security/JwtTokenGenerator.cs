using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using SecureFlow.Application.Interfaces;
using Microsoft.Extensions.Configuration;


namespace SecureFlow.Infrastructure.Security
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly string _secretKey = "MySuperSecureKey_123!"; // Daha sonra appsettings.json'a taşı
        private readonly string _issuer = "SecureFlowIssuer";
        private readonly string _audience = "SecureFlowAudience";

        private readonly IConfiguration _configuration;

        public JwtTokenGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }   

        public Task<string> GenerateTokenAsync(string username, string role)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, role)
            };

            // var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );

            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return Task.FromResult(tokenString);
        }



             public string GenerateToken(string username, string role)
    {
        return $"{username}-{role}-{Guid.NewGuid()}"; // Dummy token
    }



    }
}
