using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

using Recipe.Core.Enums;
using Recipe.Services.Interfaces;
using Recipe.Infrastracture.Constants;

namespace Recipe.Infrastracture.Requirements;

public class PermissionAuthorizationHandler(IServiceScopeFactory serviceScopeFactory)
    : AuthorizationHandler<PermissionRequirement>
{
    protected override async Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        PermissionRequirement requirement)
    {
        var claimUserId = context.User.Claims
            .FirstOrDefault(c => c.Type == CookieConstants.UserId);

        if (claimUserId is null || !Guid.TryParse(claimUserId.Value, out Guid userId))
            return;

        var permissions = await GetUserPermissions(userId);

        if (permissions.Intersect(requirement.Permissions).Any())
            context.Succeed(requirement);
    }

    private async Task<HashSet<Permission>> GetUserPermissions(Guid userId)
    {
        using var scope = serviceScopeFactory.CreateScope();

        var permissions = await scope
            .ServiceProvider
            .GetRequiredService<IPermissionService>()
            .GetPermissionsAsync(userId);

        return permissions;
    }
}
