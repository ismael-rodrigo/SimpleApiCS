using System.Security.Claims;
using BaseApplicationModule.Domain.Entities;

namespace BaseApplicationModule.Domain.Ports;

public class PayloadForGenerateToken
{
    public UserEntity user;
};

public interface IJwtService
{
    public string GenerateAccessToken(ClaimsIdentity claimsIdentity);
    public string GenerateRefreshToken(ClaimsIdentity claimsIdentity);
    public ClaimsPrincipal ValidateRefreshToken(string refreshToken);
    public List<Claim> GetClaimsByUser(UserEntity user);
}