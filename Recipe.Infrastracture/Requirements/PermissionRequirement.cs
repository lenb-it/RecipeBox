using Microsoft.AspNetCore.Authorization;

using Recipe.Core.Enums;

namespace Recipe.Infrastracture.Requirements;

public class PermissionRequirement(Permission[] permissions) 
    : IAuthorizationRequirement
{
    public Permission[] Permissions { get; set; } = permissions;
}
