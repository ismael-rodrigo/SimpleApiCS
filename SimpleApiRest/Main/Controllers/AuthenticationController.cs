using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleApiRest.Domain.Ports.Services;
using SimpleApiRest.Domain.UseCases;
using SimpleApiRest.Dtos;
using SimpleApiRest.Dtos.Request;
using SimpleApiRest.Infra;

namespace SimpleApiRest.Controllers;


[ApiController]
[Route("auth")]
public class AuthenticationController
{
    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(
        [FromServices] LoginUserUseCase loginUserUseCase,
        [FromBody] UserLoginRequestDto user )
    {
        try
        {
            var result = await loginUserUseCase.Execute(user.UserName, user.Password);
            return new OkObjectResult(result);
        }
        catch (Exception e)
        {
            return new BadRequestObjectResult(e.Message);
        }
    }
}