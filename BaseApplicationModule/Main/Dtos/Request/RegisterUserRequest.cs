using System.ComponentModel.DataAnnotations;

namespace BaseApplicationModule.Dtos.Request;

public class RegisterUserRequest
{
    [Required] public string UserName { get; set; } = string.Empty;
    [Required] public string Password { get; set; } = string.Empty;
}