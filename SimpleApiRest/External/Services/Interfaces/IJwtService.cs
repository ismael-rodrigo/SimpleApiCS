using SimpleApiRest.Domain.Models;

namespace SimpleApiRest.Domain.Ports.Services;


public class PayloadForGenerateToken
{
    public UserModel user;
};

public interface IJwtService
{
    public string GenerateAccessToken(PayloadForGenerateToken payload);
    public string GenerateRefreshToken(PayloadForGenerateToken payload);
}