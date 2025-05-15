using Recipe.Core.Models;

namespace Recipe.Core.Repositories.Interfaces;

public interface ITagRepository
{
    Task<IReadOnlyCollection<Tag>> GetAllAsync(
        CancellationToken cancellationToken = default);

    Task AddAsync(
        Tag tag,
        CancellationToken cancellationToken = default);

    Task UpdateAsync(
        Tag tag,
        CancellationToken cancellationToken = default);

    Task DeleteAsync(
        Tag tag,
        CancellationToken cancellationToken = default);

}
