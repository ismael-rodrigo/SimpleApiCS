using System.Text.Json.Serialization;
using SimpleApiRest.Domain.Entities.Shared;

namespace SimpleApiRest.Domain.Entities;

public class PostEntityInput
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public int UserId { get; set; }
}



public class PostEntity : EntityBase
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public int UserId { get; set; }
    public UserEntity User { get; set; } = null;
}