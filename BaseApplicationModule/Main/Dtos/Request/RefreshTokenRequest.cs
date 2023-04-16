using System.ComponentModel.DataAnnotations;

namespace BaseApplicationModule.Dtos.Request;

public class RefreshTokenRequest
{
   [Required] public string RefreshToken { get; }
}