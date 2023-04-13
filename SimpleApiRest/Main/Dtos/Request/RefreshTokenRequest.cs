using System.ComponentModel.DataAnnotations;

namespace SimpleApiRest.Dtos.Request;

public class RefreshTokenRequest
{
   [Required] public string RefreshToken { get; }
}