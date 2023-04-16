using BaseApplicationModule.Domain.Services.Authentication;
using BaseApplicationModule.Dtos.Request;
using Microsoft.AspNetCore.Mvc;

namespace BaseApplicationModule.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController
{
    private readonly AuthenticationService _authenticationService;

    public AuthenticationController(AuthenticationService authenticationService)
        => _authenticationService = authenticationService;
    
    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(
        [FromBody] UserLoginRequestDto user )
    {
        var result = await _authenticationService.LoginUser(user.UserName, user.Password);
        return new OkObjectResult(result);
    }
    [HttpPost]
    [Route("refresh")]
    public  IActionResult RefreshToken(
        [FromBody] RefreshTokenRequest refreshTokenDto )
    {
        var result = _authenticationService.RefreshTokens(refreshTokenDto.RefreshToken);
        return new OkObjectResult(result);
    }
}