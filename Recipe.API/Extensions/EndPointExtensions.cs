using FluentValidation;

using Recipe.Core.Enums;
using Recipe.Infrastracture.Requirements;

namespace Recipe.API.Extensions;

public static class EndPointExtensions
{
    public static IEndpointConventionBuilder RequirePermissions<TBuilder>(
        this TBuilder builder,
        params Permission[] permissions)
        where TBuilder : IEndpointConventionBuilder
    {
        return builder.RequireAuthorization(policy =>
            policy.AddRequirements(new PermissionRequirement(permissions)));
    }

    public static RouteHandlerBuilder WithSingleValidation<T>(
        this RouteHandlerBuilder builder)
        where T : class
    {
        return builder.AddEndpointFilter(async (context, next) =>
        {
            var model = context.Arguments
                .OfType<T>()
                .SingleOrDefault();

            if (model is null)
                return Results.BadRequest("Invalid model");

            var validator = context.HttpContext
                .RequestServices
                .GetRequiredService<IValidator<T>>();

            var validatorResult = validator.Validate(model);

            if (!validatorResult.IsValid)
                return Results.ValidationProblem(validatorResult.ToDictionary());

            return await next(context);
        });
    }
}
