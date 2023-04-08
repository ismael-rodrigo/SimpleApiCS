using SimpleApiRest.Domain.Ports;
using SimpleApiRest.Domain.Ports.Repository.User;

namespace SimpleApiRest.Domain.Services.Authentication;


public class LoginResponse
{
    public string AccessToken { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
}

public class AuthenticationService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtService _jwtService;
    
    public AuthenticationService(IUserRepository userRepository, IJwtService jwtService)
    {
        _userRepository = userRepository;
        _jwtService = jwtService;
    }

    public async Task<LoginResponse> LoginUser(string userName, string password)
    {
        var user = await _userRepository.FindByUserNameAsync(userName);

        if (user == null || user.Password != password)
        {
            throw new Exception("Credentials invalid");
        }

        return new LoginResponse
        {
            AccessToken = _jwtService.GenerateAccessToken(new PayloadForGenerateToken { user = user }),
            RefreshToken = _jwtService.GenerateRefreshToken(new PayloadForGenerateToken { user = user })
        };
    }
    
}