namespace Recipe.Core.Models;

public class RecipeIngredient
{
    public double Quantity { get; set; }
    public string Unit { get; set; } = null!;
    public Ingredient Ingredient { get; set; } = null!;
}
