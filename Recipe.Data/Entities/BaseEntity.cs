namespace Recipe.Data.Entities;

internal abstract class BaseEntity
{
    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set; }
}