namespace Recipe.Services.Interfaces;

public interface IUsersService
{
    Task RegisterAsync(
        string login,
        string email,
        string password,
        string firstName,
        string lastName,
        CancellationToken cancellationToken = default);

    Task<string> LoginAsync(
        string login,
        string password,
        CancellationToken cancellationToken = default);
}
