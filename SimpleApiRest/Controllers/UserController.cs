using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleApiRest.Infra;
using SimpleApiRest.Model;
using SimpleApiRest.Services;

namespace SimpleApiRest.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [Route("login2")]
        public IActionResult LoginUser()
        {
            var token = TokenService.GenerateToke("ismael");
            return Ok(token);
        }


        [HttpGet(Name = "Get Users")]
        [Authorize]
        public async Task<IActionResult> GetAllUSers(
            [FromServices] AppDataContext dbContext )
        {
            var users = await dbContext.User
                .AsNoTracking()
                .ToListAsync();


            return Ok(users);
        }

       
    }
}