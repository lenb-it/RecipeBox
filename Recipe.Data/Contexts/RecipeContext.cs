using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

using Recipe.Data.Entities;
using Recipe.Data.Configurations;
using Recipe.Core.Options;

namespace Recipe.Data.Contexts;

public class RecipeContext(
    DbContextOptions<RecipeContext> options,
    IOptions<AuthorizationOptions> authOptions) : DbContext(options)
{
    public DbSet<UserEntity> Users { get; set; } = null!;
    public DbSet<RoleEntity> Roles { get; set; } = null!;
    public DbSet<PermissionEntity> Permissions { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new RolePermissionConfiguration(authOptions.Value));
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RecipeContext).Assembly);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries().ToList();

        foreach (var entry in entries)
        {
            if (entry.Entity is not BaseEntity)
                continue;

            if (entry.State == EntityState.Modified)
                entry.Property(nameof(BaseEntity.UpdateAt)).CurrentValue = DateTime.UtcNow;

            if (entry.State == EntityState.Added)
            {
                entry.Property(nameof(BaseEntity.CreateAt)).CurrentValue = DateTime.UtcNow;
                entry.Property(nameof(BaseEntity.UpdateAt)).CurrentValue = DateTime.UtcNow;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}