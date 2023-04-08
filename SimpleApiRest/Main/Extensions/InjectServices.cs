using SimpleApiRest.Domain.Ports.Repository.User;
using SimpleApiRest.Domain.Services.Authentication;
using SimpleApiRest.Domain.Services.User;
using SimpleApiRest.External.DataBase.Repository.User;

namespace SimpleApiRest.Extensions;

public static class InjectServices
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserEntityImplRepository>();
        services.AddScoped<UserServices>();
        services.AddScoped<AuthenticationService>();
    }
}