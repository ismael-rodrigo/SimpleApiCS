using System.ComponentModel.DataAnnotations;

namespace BaseApplicationModule.Dtos.Request;

public class NewPostRequest
{
    [Required]
    public string Title { get; set; }
    [MinLength(5)]
    public string Content { get; set; }
    [Required]
    public int UserId { get; set; }
}