using Recipe.Core.Enums;
using Recipe.Core.Repositories.Interfaces;
using Recipe.Services.Interfaces;

namespace Recipe.Services;

public class PermissionService(IUsersRepository userRepository)
    : IPermissionService
{
    public async Task<HashSet<Permission>> GetPermissionsAsync(Guid userId)
    {
        return await userRepository.GetUserPermissionsAsync(userId);
    }
}
