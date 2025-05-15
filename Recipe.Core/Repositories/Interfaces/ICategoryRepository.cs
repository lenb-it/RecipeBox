using Recipe.Core.Models;

namespace Recipe.Core.Repositories.Interfaces;

public interface ICategoryRepository
{
    Task<IReadOnlyCollection<Category>> GetAllAsync(
        CancellationToken cancellationToken = default);

    Task AddAsync(
        Category category,
        CancellationToken cancellationToken = default);

    Task UpdateAsync(
        Category category,
        CancellationToken cancellationToken = default);

    Task DeleteAsync(
        Category category,
        CancellationToken cancellationToken = default);
}
