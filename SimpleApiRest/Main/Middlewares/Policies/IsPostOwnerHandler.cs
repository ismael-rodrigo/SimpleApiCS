using Microsoft.AspNetCore.Authorization;
using SimpleApiRest.Infra;

namespace SimpleApiRest.Security;

public class IsPostOwnerRequirement : IAuthorizationRequirement
{
    public IsPostOwnerRequirement(AppDataContext context)
    {
        Context = context;
    }

    public AppDataContext Context { get; set; }
}
public class IsPostOwnerHandler : AuthorizationHandler<IsPostOwnerRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsPostOwnerRequirement requirement)
    {
        var userId = context.User.Claims
            .Where(e => e.Type == "Id")
            .Select( c => c.Value)
            .SingleOrDefault();
        context.Succeed(requirement);
        return Task.CompletedTask;
    }
}