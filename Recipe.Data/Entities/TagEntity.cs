namespace Recipe.Data.Entities;

internal class TagEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<RecipeEntity> Recipes { get; set; } = [];
}
