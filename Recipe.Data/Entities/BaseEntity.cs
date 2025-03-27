namespace Recipe.Data.Entities;

public abstract class BaseEntity
{
    public DateTime CreateAt { get; set; }

    public DateTime UpdateAt { get; set; }
}