namespace Recipe.Data.Entities;

public class UserRoleEntity : BaseEntity
{
    public int RoleId { get; set; }
    public Guid UserId {  get; set; }
}
