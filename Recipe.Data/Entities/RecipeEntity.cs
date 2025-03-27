namespace Recipe.Data.Entities;

internal class RecipeEntity : BaseEntity
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Instructions { get; set; } = null!;
    public int PreparationTime { get; set; }
    public int CookingTime { get; set; }
    public int AmountServings { get; set; }
}
