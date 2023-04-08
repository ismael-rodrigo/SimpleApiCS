using Microsoft.AspNetCore.Mvc;
using SimpleApiRest.Domain.Services.Authentication;
using SimpleApiRest.Dtos.Request;
namespace SimpleApiRest.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController
{
    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(
        [FromServices] AuthenticationService authenticationService,
        [FromBody] UserLoginRequestDto user )
    {
        var result = await authenticationService.LoginUser(user.UserName, user.Password);
        return new OkObjectResult(result);
        
    }
}