namespace Recipe.Core.Repositories.Interfaces;

public interface IRecipeRepository
{
    Task<IReadOnlyCollection<Models.Recipe>> GetShortInfoPartOfRecipesAsync(
        int startPosition,
        int count,
        CancellationToken cancellationToken = default);

    Task<Models.Recipe?> GetOrDefaultAsync(
        int recipeId,
        CancellationToken cancellationToken = default);

    Task AddAsync(
        Models.Recipe recipe,
        Guid ownerId,
        CancellationToken cancellationToken = default);

    Task UpdateAsync(
        Models.Recipe recipe,
        CancellationToken cancellationToken = default);

    Task RemoveAsync(
        int recipeId,
        CancellationToken cancellationToken = default);
}
