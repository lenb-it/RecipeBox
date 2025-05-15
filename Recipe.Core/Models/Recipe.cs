namespace Recipe.Core.Models;

public class Recipe
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public UserInfo User { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Instructions { get; set; } = null!;
    public short PreparationTime { get; set; }
    public short CookingTime { get; set; }
    public short AmountServings { get; set; }
    public double? AverageRating { get; set; } = null!;
    public List<Tag> Tags { get; set; } = [];
    public List<Category> Categories { get; set; } = [];
    public List<RecipeIngredient> Ingredients { get; set; } = [];
}
