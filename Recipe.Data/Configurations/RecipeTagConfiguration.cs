using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Recipe.Data.Entities;

namespace Recipe.Data.Configurations;

internal class RecipeTagConfiguration : IEntityTypeConfiguration<RecipeTagEntity>
{
    public void Configure(EntityTypeBuilder<RecipeTagEntity> builder)
    {
        builder.HasKey(rt => new { rt.RecipeId, rt.TagId });
        builder.ToTable("RecipeTags");
    }
}
