using System.ComponentModel.DataAnnotations;

namespace SimpleApiRest.Dtos;

public class UserLoginDto
{
    [Required] public string Name { get; set; } = string.Empty;
}