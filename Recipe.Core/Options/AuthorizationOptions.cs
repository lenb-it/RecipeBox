namespace Recipe.Core.Options;

public class AuthorizationOptions
{
    public RolePermission[] RolePermissions { get; set; } = [];
}