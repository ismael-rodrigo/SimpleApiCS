using BaseApplicationModule.Infra;
using Microsoft.AspNetCore.Authorization;

namespace BaseApplicationModule.Middlewares.Policies;

public class IsPostOwnerRequirement : IAuthorizationRequirement
{
    public AppDataContext DbContext { get; set; }

    public IsPostOwnerRequirement(AppDataContext context)
    {
        DbContext = context;
    }

}
public class IsPostOwnerHandler : AuthorizationHandler<IsPostOwnerRequirement>
{
    protected override async Task<Task> HandleRequirementAsync(AuthorizationHandlerContext context, IsPostOwnerRequirement requirement)
    {
        var postId = GetPostIdValueQuery(context);
        var userId = GetUserId(context);
        if (postId is null)
        {
            context.Fail();
            return Task.CompletedTask;
        }
        var postRequired = await requirement.DbContext.Posts.FindAsync(int.Parse(postId));
        if (postRequired is not null && postRequired.UserId.Equals(userId))
        {
            context.Succeed(requirement);
            return Task.CompletedTask;
        }
        context.Fail();
        return Task.CompletedTask;
    }

    private static int GetUserId(AuthorizationHandlerContext context)
    {
        var userId = context.User.Claims.FirstOrDefault(claim => claim.Type == "Id")?.Value;
        if (userId is null) throw new UnauthorizedAccessException();
        return int.Parse(userId);
    }
    
    private static string? GetPostIdValueQuery(AuthorizationHandlerContext context)
    {
        if (context.Resource is HttpContext httpContext)
        {
            return httpContext.Request
                .Query
                .FirstOrDefault(query => query.Key == "postId").Value;
        }
        return null;
    }
    
}