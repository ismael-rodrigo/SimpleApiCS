using SimpleApiRest.Domain.Ports.Repository.User;
using SimpleApiRest.Domain.UseCases;
using SimpleApiRest.External.DataBase.EntityImplementationRepository.User;

namespace SimpleApiRest.Extensions;

public static class InjectServices
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserEntityImplRepository>();
        services.AddScoped<GenericCrudUserUseCase>();
        services.AddScoped<LoginUserUseCase>();
    }
}