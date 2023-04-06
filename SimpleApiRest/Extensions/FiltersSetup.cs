using SimpleApiRest.Filters;

namespace SimpleApiRest.Extensions;

public static class FiltersSetup
{
    public static void AddMyFilters(this IServiceCollection services)
    {
        services.AddControllers(options =>
            options.Filters.Add(new HttpResponseExceptionFilter()));

    }
}