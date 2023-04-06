using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using SimpleApiRest.Model;
using SimpleApiRest.Services.Interface;

namespace SimpleApiRest.Services
{
    public class JwtService : IJwtService
    {
        private readonly JwtSecurityTokenHandler _jwtHandler;
        private readonly SymmetricSecurityKey _securityAccessKey;
        private readonly SymmetricSecurityKey _securityRefreshKey;
        
        public JwtService (
            JwtSecurityTokenHandler jwtHandler,
            ISettings settings
            )
        {
            _jwtHandler = jwtHandler;
            _securityAccessKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.AccessSecretKey));
            _securityRefreshKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.RefreshSecretKey));

        }

        public string GenerateAccessToken(PayloadForGenerateToken payload)
        {
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(GetClains(payload.user)),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials( _securityAccessKey, SecurityAlgorithms.HmacSha256Signature )
            };

            var token = _jwtHandler.CreateToken(tokenDescriptor);
            return _jwtHandler.WriteToken(token);  

        }

        public string GenerateRefreshToken(PayloadForGenerateToken payload)
        {
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(GetClains(payload.user)),
                Expires = DateTime.UtcNow.AddHours(10),
                SigningCredentials = new SigningCredentials( _securityRefreshKey, SecurityAlgorithms.HmacSha256Signature )
            };

            var token = _jwtHandler.CreateToken(tokenDescriptor);
            return _jwtHandler.WriteToken(token);  
        }

        private List<Claim> GetClains(User user)
        {
            var clains = new List<Claim>();
            clains.Add(new Claim("Id" , user.Id.ToString()));
            clains.Add(new Claim(ClaimTypes.Name , user.FullName));
            return clains;
        }
    }
    
    
    
    

}
