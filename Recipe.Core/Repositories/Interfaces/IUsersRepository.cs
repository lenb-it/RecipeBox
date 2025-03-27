using Recipe.Core.Enums;
using Recipe.Core.Models;

namespace Recipe.Core.Repositories.Interfaces;

public interface IUsersRepository
{
    Task<User> GetByLoginAsync(string login);

    Task AddAsync(User user);

    Task<HashSet<Permission>> GetUserPermissionsAsync(Guid userId);
}
