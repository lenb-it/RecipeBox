namespace Recipe.Core.Options;

public class RolePermission
{
    public string Role { get; set; } = string.Empty;

    public string[] Permissions { get; set; } = [];
}
