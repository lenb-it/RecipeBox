namespace Recipe.Data.Entities;

internal class RecipeRatingEntity : BaseEntity
{
    public int Id { get; set; }
    public int Rating { get; set; }
    public UserEntity? User { get; set; }
    public RecipeEntity Recipe { get; set; } = null!;
}
