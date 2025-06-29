namespace Recipe.Data.Entities;

internal class RecipeIngredientEntity
{
    public int RecipeId { get; set; }
    public int IngredientId { get; set; }
    public RecipeEntity Recipe { get; set; } = null!;
    public IngredientEntity Ingredient { get; set; } = null!;
    public double Quantity { get; set; }
    public string Unit { get; set; } = null!;
}
