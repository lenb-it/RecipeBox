using Recipe.Core.Enums;

namespace Recipe.Services.Interfaces;

public interface IPermissionService
{
    Task<HashSet<Permission>> GetPermissionsAsync(
        Guid userId,
        CancellationToken cancellationToken = default);
}
