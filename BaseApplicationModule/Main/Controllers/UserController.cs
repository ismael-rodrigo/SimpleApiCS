using BaseApplicationModule.Domain.Entities;
using BaseApplicationModule.Domain.Services.User;
using BaseApplicationModule.Dtos.Request;
using Microsoft.AspNetCore.Mvc;

namespace BaseApplicationModule.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly UserServices _userServices;
        public UserController(UserServices userServices) => _userServices = userServices;
        
        [HttpGet()]
        public async Task<IActionResult> GetAllUsers() => Ok(await _userServices.FindAllAsync());
        
        
        [HttpPost()] 
        public async Task<IActionResult> RegisterNewUser( [FromBody] RegisterUserRequest userRequest )
        {
            var result = await _userServices.RegisterUser(
                new UserEntityInput
                {
                    UserName = userRequest.UserName,
                    Password = userRequest.Password
                });
            return new OkObjectResult(result);
        }
    }
}