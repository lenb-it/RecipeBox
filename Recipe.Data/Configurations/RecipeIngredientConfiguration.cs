using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Recipe.Data.Entities;

namespace Recipe.Data.Configurations;

internal class RecipeIngredientConfiguration : IEntityTypeConfiguration<RecipeIngredientEntity>
{
    public void Configure(EntityTypeBuilder<RecipeIngredientEntity> builder)
    {
        builder.HasKey(ri => ri.Id);
        builder.Property(ri => ri.Quantity)
               .IsRequired();
        builder.Property(ri => ri.Unit)
               .IsRequired()
               .HasMaxLength(50);

        builder.HasOne(ri => ri.Ingredient)
               .WithMany();
        builder.HasOne(ri => ri.Recipe)
               .WithMany(r => r.Ingredients);
    }
}
