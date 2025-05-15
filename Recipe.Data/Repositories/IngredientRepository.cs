using MapsterMapper;

using Microsoft.EntityFrameworkCore;

using Recipe.Core.Models;
using Recipe.Core.Repositories.Interfaces;
using Recipe.Data.Contexts;
using Recipe.Data.Entities;

namespace Recipe.Data.Repositories;

public class IngredientRepository(
    RecipeContext dbContext,
    IMapper mapper) : IIngredientRepository
{
    public async Task<IReadOnlyCollection<Ingredient>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        return await dbContext.Ingredients
            .AsNoTracking()
            .Select(i => mapper.Map<Ingredient>(i))
            .ToArrayAsync(cancellationToken);
    }

    public async Task AddAsync(
        Ingredient ingredient,
        CancellationToken cancellationToken = default)
    {
        var ingredientEntity = mapper.Map<IngredientEntity>(ingredient);
        ingredientEntity.Id = default;

        await dbContext.Ingredients.AddAsync(ingredientEntity, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(
        Ingredient ingredient,
        CancellationToken cancellationToken = default)
    {
        await dbContext.Ingredients
            .Where(i => i.Id == ingredient.Id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(i => i.Name, ingredient.Name),
                cancellationToken);
    }
}
