using SimpleApiRest.Domain.Entities.Shared;

namespace SimpleApiRest.Domain.Entities;

public class Post : EntityBase
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
}