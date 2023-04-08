using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleApiRest.Domain.Entities;
using SimpleApiRest.Domain.Services.User;
using SimpleApiRest.Dtos.Request;
using SimpleApiRest.Infra;

namespace SimpleApiRest.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        
        [HttpGet(Name = "Get Users")]
        [Route("post")]
        public async Task<IActionResult> GetAllUSers(
            [FromServices] AppDataContext dbContext)
        {
            var users = await dbContext.Users
                .AsNoTracking()
                .ToListAsync();
            return Ok(users);
        }

        [HttpPost(Name = "Register User")] 
        public async Task<IActionResult> RegisterNewUser(
            [FromServices] UserServices newUserServicesServices,
            [FromBody] RegisterUserRequest userRequest
        )
        {
            var result = await newUserServicesServices.RegisterUser(
                new UserModelInput
                {
                    UserName = userRequest.UserName,
                    Password = userRequest.Password
                });
            return new OkObjectResult(result);
        }
    }
}