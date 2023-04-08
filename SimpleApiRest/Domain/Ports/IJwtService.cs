using SimpleApiRest.Domain.Entities;
namespace SimpleApiRest.Domain.Ports;

public class PayloadForGenerateToken
{
    public UserModel user;
};

public interface IJwtService
{
    public string GenerateAccessToken(PayloadForGenerateToken payload);
    public string GenerateRefreshToken(PayloadForGenerateToken payload);
}