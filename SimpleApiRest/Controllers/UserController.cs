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
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        public UserController(IJwtService jwtService)
        {
            _jwtService = jwtService;
        }
        
        
        [HttpPost, Route("login")]
        public TokenResponseDto LoginUser([FromBody] User user)
        {
            var response = new TokenResponseDto {
                AccessToken = _jwtService.GenerateAccessToken( 
                    new PayloadForGenerateToken {
                        user = user
                    }),
                RefreshToken = _jwtService.GenerateRefreshToken( 
                    new PayloadForGenerateToken {
                        user = user
                    })
            };
            
            return response;
        }


        [HttpGet(Name = "Get Users")]
        [Authorize("owner")]
        public async Task<IActionResult> GetAllUSers(
            [FromServices] AppDataContext dbContext )
        {
            var users = await dbContext.Users
                .AsNoTracking()
                .ToListAsync();
            return Ok(users);
        }

       
    }
}