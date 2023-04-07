using SimpleApiRest.Domain.Ports.Repository.User;
using SimpleApiRest.Domain.Ports.Services;
using SimpleApiRest.Dtos;

namespace SimpleApiRest.Domain.UseCases;

public class LoginUserUseCase
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtService _jwtService;
    
    public LoginUserUseCase(
        IJwtService jwtService,
        IUserRepository userRepository
    )
    {
        _jwtService = jwtService;
        _userRepository = userRepository;
    }

    public async Task<TokenResponseDto> Execute(string userName, string passWord)
    {
        var userExists = await _userRepository.FindByUserName(userName);
        if (userExists == null)
        {
            throw new Exception("User not exists");
        }
        var tokenResponse = new TokenResponseDto {
            AccessToken = _jwtService.GenerateAccessToken( new PayloadForGenerateToken { user = userExists }),
            RefreshToken = _jwtService.GenerateRefreshToken( new PayloadForGenerateToken { user = userExists } )
        };
        return tokenResponse;
    }
    
}