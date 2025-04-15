using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using FluentValidation;
using Mapster;
using MapsterMapper;

using Recipe.API.Handlers;
using Recipe.API.EndPoint;
using Recipe.API.Constants;
using Recipe.Services;
using Recipe.Services.Interfaces;
using Recipe.Services.Interfaces.Auth;
using Recipe.Data.Contexts;
using Recipe.Data.Repositories;
using Recipe.Data.MappingConfigs;
using Recipe.Infrastracture;
using Recipe.Infrastracture.Constants;
using Recipe.Infrastracture.Requirements;
using Recipe.Application.Validators;
using Recipe.Core.Repositories.Interfaces;

namespace Recipe.API.Extensions;

public static class ApiExtensions
{
    public static void AddMappedEndPoins(this IEndpointRouteBuilder app)
    {
        app.MapUsersEndpoints();
    }

    public static void AddMappingConfigs(this IServiceCollection services)
    {
        var config = new TypeAdapterConfig();

        config.Scan(typeof(UserMappingConfig).Assembly);

        config.Default
            .IgnoreNullValues(false)
            .NameMatchingStrategy(NameMatchingStrategy.Exact);

        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();
    }

    public static void AddApiRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUsersRepository, UsersRepository>();
    }

    public static void AddApiServices(this IServiceCollection services)
    {
        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddScoped<IUsersService, UsersService>();
        services.AddScoped<IPermissionService, PermissionService>();

        services.AddScoped<IJwtProvider, JwtProvider>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
    }

    public static void AddValidation(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(
            typeof(LoginUserRequestValidator).Assembly,
            includeInternalTypes: true);
    }

    public static void AddDbContext(
        this IServiceCollection services,
        IConfiguration configuration,
        IWebHostEnvironment environment)
    {
        services.AddDbContext<RecipeContext>(options =>
        {
            var connectionName = environment.IsProduction()
                ? DbConnectionConstants.ProductionConnection
                : DbConnectionConstants.DebugConnection;
            var connectionString = configuration.GetConnectionString(connectionName)
                ?? throw new ArgumentException("Connection string can't be empty");

            options.UseSqlServer(connectionString);
        });
    }

    public static void AddApiAuthentication(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var jwtOptions = configuration
            .GetSection(nameof(JwtOptions))
            .Get<JwtOptions>();

        services
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.RequireHttpsMetadata = true;
                options.SaveToken = true;

                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtOptions!.SecretKey)),
                };

                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        context.Token = context.Request.Cookies[CookieConstants.JwtToken];

                        return Task.CompletedTask;
                    }
                };
            });

        services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();

        services.AddAuthorization();
    }

    public static void UseApiCookiePolicy(this IApplicationBuilder app)
    {
        app.UseCookiePolicy(new CookiePolicyOptions
        {
            HttpOnly = HttpOnlyPolicy.Always,
            Secure = CookieSecurePolicy.Always,
            CheckConsentNeeded = context => false,
            MinimumSameSitePolicy = SameSiteMode.Strict,
            ConsentCookie = new CookieBuilder
            {
                HttpOnly = true,
                SameSite = SameSiteMode.Strict,
                SecurePolicy = CookieSecurePolicy.Always,
                Name = nameof(CookiePolicyOptions.ConsentCookie),
                Expiration = TimeSpan.FromDays(CookieConstants.AuthExpiration),
            },
        });
    }
}
