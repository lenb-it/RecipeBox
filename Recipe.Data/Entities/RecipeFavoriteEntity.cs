namespace Recipe.Data.Entities;

internal class RecipeFavoriteEntity
{
    public int Id { get; set; }
    public UserEntity User { get; set; } = null!;
    public RecipeEntity Recipe { get; set; } = null!;

    public DateTime CreateAt { get; set; }
}
