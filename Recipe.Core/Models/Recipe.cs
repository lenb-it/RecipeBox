namespace Recipe.Core.Models;

public class Recipe
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public User User { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Instructions { get; set; } = null!;
    public short PreparationTime { get; set; }
    public short CookingTime { get; set; }
    public short AmountServings { get; set; }
    public double? AverageRating { get; set; } = null!;
    public ICollection<Tag> Tags { get; set; } = [];
    public ICollection<Category> Categories { get; set; } = [];
    public ICollection<RecipeIngredient> Ingredients { get; set; } = [];
}
