namespace Recipe.Services.Interfaces;

public interface IUsersService
{
    Task RegisterAsync(
        string login,
        string email,
        string password,
        string firstName,
        string lastName);

    Task<string> LoginAsync(string login, string password);
}
