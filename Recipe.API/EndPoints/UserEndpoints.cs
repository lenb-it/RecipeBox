using Microsoft.AspNetCore.Mvc;

using Recipe.API.Extensions;
using Recipe.Core.Enums;
using Recipe.Core.Exceptions;
using Recipe.Services.Interfaces;
using Recipe.Infrastracture.Constants;
using Recipe.Application.EndPointModels;

namespace Recipe.API.EndPoint;

public static class UserEndpoints
{
    public static IEndpointRouteBuilder MapUsersEndpoints(this IEndpointRouteBuilder app)
    {
        var endPoints = app.MapGroup("User");

        endPoints.MapPost("Register", RegisterAsync)
            .WithSingleValidation<RegisterUserRequest>();

        endPoints.MapPost("Login", LoginAsync)
            .WithSingleValidation<LoginUserRequest>();

        endPoints.MapPost("get", get)
            .RequirePermissions(Permission.ReadPost);

        return endPoints;
    }

    private static IResult get(HttpContext context)
    {
        return Results.Ok("ok");
    }

    public static async Task<IResult> RegisterAsync(
        [FromBody] RegisterUserRequest request,
        IUsersService userService)
    {
        try
        {
            await userService.RegisterAsync(
                request.Login,
                request.Email,
                request.Password,
                request.FirstName,
                request.LastName);

            return Results.Ok();
        }
        catch (BaseException ex)
        {
            return Results.BadRequest(ex.Message);
        }
    }

    public static async Task<IResult> LoginAsync(
        [FromBody] LoginUserRequest request,
        HttpContext context,
        IUsersService userService)
    {
        try
        {
            var token = await userService.LoginAsync(request.Login, request.Password);
            context.Response.Cookies.Append(CookieConstants.JwtToken, token);

            return Results.Ok();
        }
        catch (BaseException ex)
        {
            return Results.BadRequest(ex.Message);
        }
    }
}