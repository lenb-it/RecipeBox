﻿using Recipe.Core.Models;

namespace Recipe.Core.Repositories.Interfaces;

public interface IIngredientRepository
{
    Task<IReadOnlyCollection<Ingredient>> GetAllAsync(
        CancellationToken cancellationToken = default);

    Task AddAsync(
        Ingredient ingredient,
        CancellationToken cancellationToken = default);

    Task UpdateAsync(
        Ingredient ingredient,
        CancellationToken cancellationToken = default);
}
