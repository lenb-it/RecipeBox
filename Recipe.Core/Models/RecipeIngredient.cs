namespace Recipe.Core.Models;

public class RecipeIngredient
{
    public int Id { get; set; }
    public double Quantity { get; set; }
    public string Unit { get; set; } = null!;
    public Ingredient Ingredient { get; set; } = null!;
}
