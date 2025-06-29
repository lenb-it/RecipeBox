using Microsoft.AspNetCore.Http;

using Recipe.Services.Interfaces;
using Recipe.Infrastracture.Constants;
using Recipe.Core.Exceptions;

namespace Recipe.Services;

public class CookieService(
    IHttpContextAccessor contextAccesor) : ICookieService
{
    private HttpContext GetHttpContext() => contextAccesor.HttpContext
        ?? throw new InvalidOperationException("HttpContext isn't availvable");

    public Guid GetUserId()
    {
        var context = GetHttpContext();

        var userId = context.User.FindFirst(CookieConstants.UserId)?.Value;

        if (string.IsNullOrWhiteSpace(userId)
            || !Guid.TryParse(userId, out Guid userIdGuid))
        {
            throw new InvalidException($"Invalid {CookieConstants.UserId} in the cookies");
        }

        return userIdGuid;
    }
}
