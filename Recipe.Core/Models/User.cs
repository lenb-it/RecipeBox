namespace Recipe.Core.Models;

public class User
{
    public Guid Id { get; set; }
    public string Login { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;

    public static User Create(
        string login,
        string email,
        string passwordHash,
        string firstName,
        string lastName)
    {
        return new User
        {
            Login = login,
            Email = email,
            PasswordHash = passwordHash,
            FirstName = firstName,
            LastName = lastName,
        };
    }
}
