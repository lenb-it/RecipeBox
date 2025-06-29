using Recipe.API.Extensions;
using Recipe.Core.Enums;
using Recipe.Core.Repositories.Interfaces;
using Recipe.Services.Interfaces;

namespace Recipe.API.EndPoints;

internal static class RecipeEndpoints
{
    public static IEndpointRouteBuilder MapRecipeEndpoints(this IEndpointRouteBuilder app)
    {
        var endPoints = app.MapGroup("Recipe");

        endPoints.MapPost("Add", AddAsync)
            .RequireAuthorization()
            .RequirePermissions(Permission.CreatePost);
            //.WithSingleValidation<Core.Models.Recipe>();

        return endPoints;
    }

    public static async Task<IResult> AddAsync(
        Core.Models.Recipe recipe,
        IRecipeRepository recipeRepository,
        ICookieService cookieService,
        CancellationToken cancellationToken)
    {
        var userId = cookieService.GetUserId();
        await recipeRepository.AddAsync(recipe, userId, cancellationToken);

        return Results.Ok();
    }
}
