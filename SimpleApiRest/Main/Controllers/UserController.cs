using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleApiRest.Domain.Entity;
using SimpleApiRest.Domain.UseCases;
using SimpleApiRest.External.DataBase.EntityImplementationRepository.User;
using SimpleApiRest.Infra;

namespace SimpleApiRest.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        
        [HttpGet(Name = "Get Users")]
        [Authorize]
        public async Task<IActionResult> GetAllUSers(
            [FromServices] AppDataContext dbContext )
        {
            var users = await dbContext.Users
                .AsNoTracking()
                .ToListAsync();
            return Ok(users);
        }

        [HttpPost(Name = "Register User")] 
        public async Task<IActionResult> RegisterNewUser(
            [FromServices] CreateNewUser newUserUseCase,
            [FromBody] UserEntityInput entityInput
        )
        {
            var result = await newUserUseCase.Execute(entityInput);
            return new OkObjectResult(result);
        }
    }
}