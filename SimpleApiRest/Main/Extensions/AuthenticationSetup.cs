using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using SimpleApiRest.Domain.Ports.Services;
using SimpleApiRest.Infra;
using SimpleApiRest.Security;
using SimpleApiRest.Services;

namespace SimpleApiRest.Extensions;

public static class AuthenticationSetup
{
    public static void AddAuthorizationPolicies(this IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
            options.AddPolicy("owner",
                policy => policy.Requirements.Add(new IsPostOwnerRequirement(new AppDataContext())));
        });
        services.AddSingleton<IAuthorizationHandler, IsPostOwnerHandler>();
    }
    
    
    public static void RegisterAuthenticationSetup(this IServiceCollection services , IConfiguration configuration)
    {
        var accessKey = Encoding.ASCII.GetBytes(configuration.GetValue<string>("Jwt:AccessToken:Key"));

        services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(accessKey),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });
        
        services.AddSingleton(new JwtSecurityTokenHandler());
        services.AddSingleton<IJwtService, JwtService>();
    }
}