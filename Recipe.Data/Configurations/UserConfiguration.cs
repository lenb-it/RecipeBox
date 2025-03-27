using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Recipe.Application.Validators.Constants;
using Recipe.Data.Entities;

namespace Recipe.Data.Configurations;

internal class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).ValueGeneratedOnAdd();
        builder.Property(u => u.Login)
               .HasMaxLength(UserConstants.MaxLengthLogin)
               .IsRequired();
        builder.Property(u => u.FirstName)
               .HasMaxLength(UserConstants.MaxLengthFirstName)
               .IsRequired();
        builder.Property(u => u.LastName)
               .HasMaxLength(UserConstants.MaxLengthLastName)
               .IsRequired();
        builder.Property(u => u.Email).HasMaxLength(254).IsRequired();
        builder.HasIndex(u => u.Email).IsUnique();
        // todo изменить макс длину 
        builder.Property(u => u.PasswordHash).HasMaxLength(512).IsRequired();
        builder.HasMany(u => u.Roles)
               .WithMany(r => r.Users)
               .UsingEntity<UserRoleEntity>(
                    l => l.HasOne<RoleEntity>().WithMany().HasForeignKey(r => r.RoleId),
                    r => r.HasOne<UserEntity>().WithMany().HasForeignKey(u => u.UserId));
    }
}