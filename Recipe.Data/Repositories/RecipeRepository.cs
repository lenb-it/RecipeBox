using MapsterMapper;

using Microsoft.EntityFrameworkCore;

using Recipe.Core.Repositories.Interfaces;
using Recipe.Data.Contexts;

namespace Recipe.Data.Repositories;
public class RecipeRepository(
    RecipeContext dbContext,
    IMapper mapper) : IRecipeRepository
{
    public async Task<IReadOnlyCollection<Core.Models.Recipe>> GetShortInfoPartOfRecipesAsync(
        int startPosition,
        int count,
        CancellationToken cancellationToken = default)
    {
        return await dbContext.Recipes
            .AsNoTracking()
            .Skip(startPosition)
            .Take(count)
            .Select(r => mapper.Map<Core.Models.Recipe>(r))
            .ToArrayAsync(cancellationToken);
    }

    public async Task<Core.Models.Recipe?> GetOrDefaultAsync(
        int recipeId,
        CancellationToken cancellationToken = default)
    {
        var recipe = await dbContext.Recipes
            .AsNoTracking()
            .Include(r => r.Tags)
            .Include(r => r.Ratings)
            .Include(r => r.Ingredients)
            .Include(r => r.Categories)
            .Include(r => r.User)
            .FirstOrDefaultAsync(r => r.Id == recipeId, cancellationToken);

        if (recipe is null)
            return null;

        return mapper.Map<Core.Models.Recipe>(recipe);
    }

    public Task AddAsync(
        Core.Models.Recipe recipe,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(
        Core.Models.Recipe recipe,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(
        int recipeId,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
