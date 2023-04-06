using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleApiRest.Dtos;
using SimpleApiRest.Dtos.Request;
using SimpleApiRest.Infra;
using SimpleApiRest.Services.Interface;

namespace SimpleApiRest.Controllers;


[ApiController]
[Route("auth")]
public class AuthenticationController
{
    private readonly IJwtService _jwtService;
    public AuthenticationController( IJwtService jwtService ) { _jwtService = jwtService; }
    
    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(
        [FromServices] AppDataContext dbContext,
        [FromBody] UserLoginRequestDto user )
    {

        var userInDb = await dbContext.Users
            .AsNoTracking()
            .Where(userDb => userDb.FullName == user.FullName)
            .FirstOrDefaultAsync();
        
        if (userInDb == null)
        {
            return new BadRequestObjectResult("User not exists");
        }

        var tokenResponse = new TokenResponseDto {
                AccessToken = _jwtService.GenerateAccessToken( new PayloadForGenerateToken { user = userInDb }),
                RefreshToken = _jwtService.GenerateRefreshToken( new PayloadForGenerateToken { user = userInDb } )
        };

        return new OkObjectResult(tokenResponse);
        }


}


    