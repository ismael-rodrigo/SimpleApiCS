using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleApiRest.Dtos;
using SimpleApiRest.Infra;
using SimpleApiRest.Model;
using SimpleApiRest.Services;
using SimpleApiRest.Services.Interface;

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
            [FromServices] AppDataContext dbContext,
            [FromBody] User user
            
            )
        {
            var users = dbContext.Users.Add(
                new User
                {
                    FullName = user.FullName,
                    Password = user.Password
                });
            await dbContext.SaveChangesAsync();
            return Ok(users.Entity);
        }
    }
}