﻿using Microsoft.AspNetCore.Mvc;

using Recipe.API.Extensions;
using Recipe.Core.Enums;
using Recipe.Core.Exceptions;
using Recipe.Services.Interfaces;
using Recipe.Infrastracture.Constants;
using Recipe.Application.EndPointModels;

namespace Recipe.API.EndPoint;

public static class UserEndpoints
{
    public static IEndpointRouteBuilder MapUserEndpoints(this IEndpointRouteBuilder app)
    {
        var endPoints = app.MapGroup("User");

        endPoints.MapPost("Register", RegisterAsync)
            .WithSingleValidation<RegisterUserRequest>();

        endPoints.MapPost("Login", LoginAsync)
            .WithSingleValidation<LoginUserRequest>();

        endPoints.MapGet("get", get)
            .RequirePermissions(Permission.ReadPost);

        return endPoints;
    }

    private static IResult get(HttpContext context)
    {
        return Results.Ok("ok");
    }

    public static async Task<IResult> RegisterAsync(
        [FromBody] RegisterUserRequest request,
        IUsersService userService,
        CancellationToken cancellationToken = default)
    {
        try
        {
            await userService.RegisterAsync(
                request.Login,
                request.Email,
                request.Password,
                request.FirstName,
                request.LastName,
                cancellationToken);

            return Results.Ok();
        }
        catch (BaseException ex)
        {
            return Results.BadRequest(ex.Message);
        }
    }

    public static async Task<IResult> LoginAsync(
        [FromBody] LoginUserRequest request,
        IUsersService userService,
        HttpContext context,
        CancellationToken cancellationToken)
    {
        try
        {
            var token = await userService.LoginAsync(
                request.Login,
                request.Password,
                cancellationToken);
            context.Response.Cookies.Append(CookieConstants.JwtToken, token);

            return Results.Ok();
        }
        catch (BaseException ex)
        {
            return Results.BadRequest(ex.Message);
        }
    }
}