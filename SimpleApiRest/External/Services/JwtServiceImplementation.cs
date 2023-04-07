﻿using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using SimpleApiRest.Domain.Models;
using SimpleApiRest.Domain.Ports.Services;

namespace SimpleApiRest.Services
{
    public class JwtServiceImplementation : IJwtService
    {
        private readonly JwtSecurityTokenHandler _jwtHandler;
        private readonly SymmetricSecurityKey _securityAccessKey;
        private readonly SymmetricSecurityKey _securityRefreshKey;
        
        public JwtServiceImplementation (
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

        private List<Claim> GetClains(UserModel user)
        {
            var clains = new List<Claim>();
            clains.Add(new Claim("Id" , user.Id.ToString()));
            clains.Add(new Claim(ClaimTypes.Name , user.FullName));
            return clains;
        }
    }
    
    
    
    

}