using Recipe.Core.Models;

namespace Recipe.Core.Repositories.Interfaces;

public interface IIngredientRepository
{
    Task<List<Ingredient>> GetAllAsync(
        CancellationToken cancellationToken = default);

    Task AddAsync(
        Ingredient ingredient,
        CancellationToken cancellationToken = default);
}
