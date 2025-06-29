using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Recipe.Data.Entities;

namespace Recipe.Data.Configurations;

internal class RecipeIngredientConfiguration : IEntityTypeConfiguration<RecipeIngredientEntity>
{
    public void Configure(EntityTypeBuilder<RecipeIngredientEntity> builder)
    {
        builder.HasKey(ri => new { ri.RecipeId, ri.IngredientId });
        builder.ToTable("RecipeIngredients");
        builder.Property(ri => ri.Quantity)
               .IsRequired();
        builder.Property(ri => ri.Unit)
               .IsRequired()
               .HasMaxLength(50);

        builder.HasOne(ri => ri.Ingredient)
               .WithMany()
               .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(ri => ri.Recipe)
               .WithMany(r => r.Ingredients)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
