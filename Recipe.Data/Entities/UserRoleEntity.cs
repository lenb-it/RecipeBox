namespace Recipe.Data.Entities;

internal class UserRoleEntity : BaseEntity
{
    public int RoleId { get; set; }
    public Guid UserId {  get; set; }
}
