using Microsoft.AspNetCore.Authorization;
using SimpleApiRest.Infra;

namespace SimpleApiRest.Middlewares.Policies;

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
        if (postId == null)
        {
            context.Fail();
            return Task.CompletedTask;
        }
        var postRequired = await requirement.DbContext.Posts.FindAsync(int.Parse(postId));
        if (postRequired == null ||
            !postRequired.UserId.Equals(GetUserId(context)))
        {
            context.Fail();
            return Task.CompletedTask;
        }
        
        context.Succeed(requirement);
        return Task.CompletedTask;
    }

    private static string? GetUserId(AuthorizationHandlerContext context)
    {
        return context.User.Claims.FirstOrDefault(claim => claim.Type == "Id")?.Value;
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