using System.Security.Claims;
using BaseApplicationModule.Domain.Ports;
using BaseApplicationModule.Domain.Ports.Repository.User;

namespace BaseApplicationModule.Domain.Services.Authentication;


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

        var userClaims = new ClaimsIdentity(_jwtService.GetClaimsByUser(user)); 
        
        return new LoginResponse
        {
            AccessToken = _jwtService.GenerateAccessToken(userClaims),
            RefreshToken = _jwtService.GenerateRefreshToken(userClaims)
        };
    }


    public LoginResponse RefreshTokens(string refreshToken)
    {
        var claimsPrincipal = _jwtService.ValidateRefreshToken(refreshToken);
        var userClaims = new ClaimsIdentity(claimsPrincipal.Claims);
        return new LoginResponse
        {
            AccessToken = _jwtService.GenerateAccessToken(userClaims),
            RefreshToken = _jwtService.GenerateRefreshToken(userClaims)
        };
    }

}