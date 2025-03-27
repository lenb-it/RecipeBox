namespace Recipe.Data.Entities;

internal class RecipeIngredientEntity
{
    public int Id { get; set; }
    public RecipeEntity Recipe { get; set; } = null!;
    public IngredientEntity Ingredient { get; set; } = null!;
    public double Quantity { get; set; }
    public string Unit { get; set; } = null!;
}
