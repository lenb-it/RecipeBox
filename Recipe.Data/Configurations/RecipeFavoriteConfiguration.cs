using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Recipe.Data.Entities;

namespace Recipe.Data.Configurations;

internal class RecipeFavoriteConfiguration
    : IEntityTypeConfiguration<RecipeFavoriteEntity>
{
    public void Configure(EntityTypeBuilder<RecipeFavoriteEntity> builder)
    {
        builder.HasKey(rf => rf.Id);
        builder.ToTable("UserRecipeFavorites");
        builder.HasOne(rf => rf.User)
               .WithMany(u => u.RecipeFavorites)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(rf => rf.Recipe)
               .WithMany(r => r.UserFavorites)
               .IsRequired()
               .OnDelete(DeleteBehavior.ClientCascade);
    }
}
