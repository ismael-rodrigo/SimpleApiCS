using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleApiRest.Constants;
using SimpleApiRest.Domain.Entity;
using SimpleApiRest.Domain.Models;
using SimpleApiRest.Domain.UseCases;
using SimpleApiRest.Dtos.Request;
using SimpleApiRest.External.DataBase.EntityImplementationRepository.User;
using SimpleApiRest.Infra;

namespace SimpleApiRest.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        
        [HttpGet(Name = "Get Users")]
        [Route("post")]
        [Authorize(Policies.PostOwner)]
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
            [FromServices] GenericCrudUserUseCase newUserUseCaseUseCase,
            [FromBody] RegisterUserRequest userRequest
        )
        {
            var result = await newUserUseCaseUseCase.Execute(new UserEntityInput
            {
                UserName = userRequest.UserName,
                Password = userRequest.Password
            });
            return new OkObjectResult(result);
        }
    }
}