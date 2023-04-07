using System.ComponentModel.DataAnnotations;

namespace SimpleApiRest.Dtos.Request;

public class UserLoginRequestDto
{
    [Required] public string FullName { get; set; } = string.Empty;
    [Required] public string Password { get; set; } = string.Empty;
}