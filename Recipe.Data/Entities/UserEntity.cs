namespace Recipe.Data.Entities;

internal class UserEntity : BaseEntity
{
    public Guid Id { get; set; }
    public string Login { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public ICollection<RoleEntity> Roles { get; set; } = [];
    public ICollection<RecipeEntity> Recipes { get; set; } = [];
    public ICollection<RecipeFavoriteEntity> RecipeFavorites { get; set; } = [];
}