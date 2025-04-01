using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Recipe.Data.Entities;

namespace Recipe.Data.Configurations;

internal class UserRoleConfiguration : IEntityTypeConfiguration<UserRoleEntity>
{
    public void Configure(EntityTypeBuilder<UserRoleEntity> builder)
    {
        builder.HasKey(ur => new { ur.RoleId, ur.UserId });
        builder.ToTable("UserRoles");
    }
}
