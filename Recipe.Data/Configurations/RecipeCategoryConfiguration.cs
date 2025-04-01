using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Recipe.Data.Entities;

namespace Recipe.Data.Configurations;

internal class RecipeCategoryConfiguration : IEntityTypeConfiguration<RecipeCategoryEntity>
{
    public void Configure(EntityTypeBuilder<RecipeCategoryEntity> builder)
    {
        builder.HasKey(rc => new { rc.RecipeId, rc.CategoryId });
        builder.ToTable("RecipeCategories");
    }
}
