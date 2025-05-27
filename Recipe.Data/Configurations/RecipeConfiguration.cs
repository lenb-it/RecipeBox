using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Recipe.Data.Entities;

namespace Recipe.Data.Configurations;

internal class RecipeConfiguration : IEntityTypeConfiguration<RecipeEntity>
{
    public void Configure(EntityTypeBuilder<RecipeEntity> builder)
    {
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Title)
               .IsRequired()
               .HasMaxLength(128);
        builder.Property(r => r.Description)
               .IsRequired()
               .HasMaxLength(2000);
        builder.Property(r => r.Instructions)
               .IsRequired();

        builder.Property(r => r.AmountServings).IsRequired();
        builder.Property(r => r.CookingTime).IsRequired();
        builder.Property(r => r.PreparationTime).IsRequired();

        builder.HasOne(r => r.User)
               .WithMany(u => u.Recipes)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(r => r.Ingredients)
               .WithOne(ri => ri.Recipe)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(r => r.Categories)
               .WithMany(c => c.Recipes)
               .UsingEntity<RecipeCategoryEntity>(
                    l => l.HasOne<CategoryEntity>().WithMany().HasForeignKey(r => r.CategoryId),
                    r => r.HasOne<RecipeEntity>().WithMany().HasForeignKey(u => u.RecipeId));

        builder.HasMany(r => r.Tags)
               .WithMany(c => c.Recipes)
               .UsingEntity<RecipeTagEntity>(
                    l => l.HasOne<TagEntity>().WithMany().HasForeignKey(r => r.TagId),
                    r => r.HasOne<RecipeEntity>().WithMany().HasForeignKey(u => u.RecipeId));
    }
}