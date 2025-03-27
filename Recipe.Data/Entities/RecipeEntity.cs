namespace Recipe.Data.Entities;

internal class RecipeEntity : BaseEntity
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public UserEntity User { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Instructions { get; set; } = null!;
    public short PreparationTime { get; set; }
    public short CookingTime { get; set; }
    public short AmountServings { get; set; }
    public ICollection<TagEntity> Tags { get; set; } = [];
    public ICollection<CategoryEntity> Categories { get; set; } = [];
    public ICollection<RecipeRatingEntity> Ratings { get; set; } = [];
    public ICollection<RecipeIngredientEntity> Ingredients { get; set;} = [];
    public ICollection<RecipeFavoriteEntity> UserFavorites { get; set;} = [];
}
