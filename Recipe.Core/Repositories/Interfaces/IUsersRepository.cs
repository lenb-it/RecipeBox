using Recipe.Core.Enums;
using Recipe.Core.Models;

namespace Recipe.Core.Repositories.Interfaces;

public interface IUsersRepository
{
    Task<User> GetByLoginAsync(
        string login,
        CancellationToken cancellationToken = default);

    Task AddAsync(
        User user,
        CancellationToken cancellationToken = default);

    Task<HashSet<Permission>> GetUserPermissionsAsync(
        Guid userId,
        CancellationToken cancellationToken = default);
}
