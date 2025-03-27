namespace Recipe.Application.EndPointModels;

public record LoginUserRequest(
    string Login = null!,
    string Password = null!);
