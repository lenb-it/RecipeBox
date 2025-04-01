using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Recipe.Data.Entities;

namespace Recipe.Data.Configurations;

internal class RecipeRatingConfiguration : IEntityTypeConfiguration<RecipeRatingEntity>
{
    public void Configure(EntityTypeBuilder<RecipeRatingEntity> builder)
    {
        builder.HasKey(rr => rr.Id);
        builder.ToTable("RecipeRatings");
        builder.Property(rr => rr.Rating)
               .IsRequired()
               .HasConversion(
                    v => Math.Clamp(v, 1, 5),
                    v => v);

        builder.HasOne(rr => rr.User)
               .WithMany()
               .IsRequired(false)
               .OnDelete(DeleteBehavior.ClientSetNull);
        builder.HasOne(rr => rr.Recipe)
               .WithMany(r => r.Ratings)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);
    }
}
