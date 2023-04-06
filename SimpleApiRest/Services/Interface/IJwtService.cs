using SimpleApiRest.Model;

namespace SimpleApiRest.Services.Interface;


public class PayloadForGenerateToken
{
    public User user;
};


public interface IJwtService
{
    public string GenerateAccessToken(PayloadForGenerateToken payload);
    public string GenerateRefreshToken(PayloadForGenerateToken payload);
}