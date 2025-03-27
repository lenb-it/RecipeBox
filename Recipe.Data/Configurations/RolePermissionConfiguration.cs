using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Recipe.Core.Enums;
using Recipe.Core.Options;
using Recipe.Data.Entities;

namespace Recipe.Data.Configurations;

internal class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermissionEntity>
{
    private readonly AuthorizationOptions _options;

    public RolePermissionConfiguration(AuthorizationOptions options)
    {
        _options = options;
    }

    public void Configure(EntityTypeBuilder<RolePermissionEntity> builder)
    {
        builder.HasKey(ur => new { ur.RoleId, ur.PermissionId });

        builder.HasData(ParseRolePermissions());
    }

    private RolePermissionEntity[] ParseRolePermissions()
    {
        return _options.RolePermissions
            .SelectMany(rp => rp.Permissions
                .Select(p => new RolePermissionEntity
                {
                    RoleId = (int)Enum.Parse<Role>(rp.Role),
                    PermissionId = (int)Enum.Parse<Permission>(p),
                }))
                .ToArray();
    }
}
