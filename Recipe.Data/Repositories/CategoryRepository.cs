using MapsterMapper;

using Microsoft.EntityFrameworkCore;

using Recipe.Core.Models;
using Recipe.Core.Repositories.Interfaces;
using Recipe.Data.Contexts;
using Recipe.Data.Entities;

namespace Recipe.Data.Repositories;

public class CategoryRepository(
    RecipeContext dbContext,
    IMapper mapper) : ICategoryRepository
{
    public async Task<IReadOnlyCollection<Category>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        return await dbContext.Categories
            .AsNoTracking()
            .Select(c => mapper.Map<Category>(c))
            .ToArrayAsync(cancellationToken);
    }

    public async Task AddAsync(
        Category category,
        CancellationToken cancellationToken = default)
    {
        var categoryEntity = mapper.Map<CategoryEntity>(category);
        categoryEntity.Id = default;

        await dbContext.AddAsync(categoryEntity, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(
        Category category,
        CancellationToken cancellationToken = default)
    {
        await dbContext.Categories
            .Where(c => c.Id == category.Id)
            .ExecuteUpdateAsync(x => x
                .SetProperty(c => c.Name, category.Name),
                cancellationToken);
    }

    public async Task DeleteAsync(
        Category category,
        CancellationToken cancellationToken = default)
    {
        await dbContext.Categories
            .Where(c => c.Id == category.Id)
            .ExecuteDeleteAsync(cancellationToken);
    }
}