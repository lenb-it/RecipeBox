using MapsterMapper;

using Microsoft.EntityFrameworkCore;

using Recipe.Core.Exceptions;
using Recipe.Core.Models;
using Recipe.Core.Repositories.Interfaces;
using Recipe.Data.Contexts;
using Recipe.Data.Entities;

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

    // todo check the method for correctness
    public async Task AddAsync(
        Core.Models.Recipe recipe,
        Guid ownerId,
        CancellationToken cancellationToken = default)
    {
        var userOwner = await dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == ownerId, cancellationToken)
            ?? throw new NotFoundException($"User with id:\'{ownerId}\' not found");

        var recipeEntity = mapper.Map<RecipeEntity>(recipe);
        recipeEntity.Id = 0;
        recipeEntity.User = userOwner;

        await dbContext.Recipes.AddAsync(recipeEntity, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public Task UpdateAsync(
        Core.Models.Recipe recipe,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task RemoveAsync(
        int recipeId,
        CancellationToken cancellationToken = default)
    {
        var recipeEntity = await dbContext.Recipes
            .FirstOrDefaultAsync(r => r.Id == recipeId, cancellationToken);

        if (recipeEntity is null)
            return;

        dbContext.Recipes.Remove(recipeEntity);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
