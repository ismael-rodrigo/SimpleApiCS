using BaseApplicationModule.Domain.Ports.Repository.Post;
using BaseApplicationModule.Domain.Ports.Repository.User;
using BaseApplicationModule.Domain.Services.Authentication;
using BaseApplicationModule.Domain.Services.Post;
using BaseApplicationModule.Domain.Services.User;
using BaseApplicationModule.External.DataBase.Repository.Post;
using BaseApplicationModule.External.DataBase.Repository.User;

namespace BaseApplicationModule.Extensions;

public static class InjectServices
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserEntityImplRepository>();
        services.AddScoped<UserServices>();
        services.AddScoped<IPostRepository, PostEntityImplRepository>();
        services.AddScoped<PostService>();
        services.AddScoped<AuthenticationService>();
    }
}