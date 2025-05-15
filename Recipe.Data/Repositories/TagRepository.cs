using MapsterMapper;

using Microsoft.EntityFrameworkCore;

using Recipe.Core.Models;
using Recipe.Core.Repositories.Interfaces;
using Recipe.Data.Contexts;
using Recipe.Data.Entities;

namespace Recipe.Data.Repositories;

public class TagRepository(
    RecipeContext dbContext,
    IMapper mapper) : ITagRepository
{
    public async Task<IReadOnlyCollection<Tag>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        return await dbContext.Tags
            .AsNoTracking()
            .Select(t => mapper.Map<Tag>(t))
            .ToArrayAsync(cancellationToken);
    }

    public async Task AddAsync(
        Tag tag,
        CancellationToken cancellationToken = default)
    {
        var tagEntity = mapper.Map<TagEntity>(tag);
        tagEntity.Id = default;

        await dbContext.Tags.AddAsync(tagEntity, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(
        Tag tag,
        CancellationToken cancellationToken = default)
    {
        await dbContext.Tags
            .Where(t => t.Id == tag.Id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(t => t.Name, tag.Name), 
                cancellationToken);
    }

    public async Task DeleteAsync(
        Tag tag,
        CancellationToken cancellationToken = default)
    {
        await dbContext.Tags
            .Where(t => t.Id == tag.Id)
            .ExecuteDeleteAsync(cancellationToken);
    }
}
