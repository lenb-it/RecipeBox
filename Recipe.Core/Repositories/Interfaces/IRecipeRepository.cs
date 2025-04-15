using Recipe.Core.Models;

namespace Recipe.Core.Repositories.Interfaces;

public interface IRecipeRepository
{
    Task<List<Models.Recipe>> GetPartAsync(
        int startPosition,
        int count,
        CancellationToken cancellationToken = default);

    Task AddAsync(
        Models.Recipe recipe,
        CancellationToken cancellationToken = default);

    Task UpdateAsync(
        Models.Recipe recipe,
        CancellationToken cancellationToken = default);
}
