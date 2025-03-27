namespace Recipe.Application.EndPointModels;

public record RegisterUserRequest(
    string Login = null!,
    string Email = null!,
    string Password = null!,
    string FirstName = null!,
    string LastName = null!);
