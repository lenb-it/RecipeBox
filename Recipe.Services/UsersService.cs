using Recipe.Core.Models;
using Recipe.Core.Exceptions;
using Recipe.Core.Repositories.Interfaces;
using Recipe.Services.Interfaces;
using Recipe.Services.Interfaces.Auth;

namespace Recipe.Services;

public class UsersService(
    IUsersRepository userRepository,
    IPasswordHasher passwordHasher,
    IJwtProvider jwtProvider) : IUsersService
{
    public async Task RegisterAsync(
        string login,
        string email,
        string password,
        string firstName,
        string lastName)
    {
        var hashedPassword = passwordHasher.Generate(password);
        var user = User.Create(login, email, hashedPassword, firstName, lastName);

        await userRepository.AddAsync(user);
    }

    public async Task<string> LoginAsync(string login, string password)
    {
        var user = await userRepository.GetByLoginAsync(login);
        var verifyResult = passwordHasher.Verify(password, user.PasswordHash);

        if (!verifyResult)
            throw new BadAuthException("Password don't match");

        return jwtProvider.GenerateToken(user);
    }
}