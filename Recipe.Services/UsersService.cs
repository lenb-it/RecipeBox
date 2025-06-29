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
        string lastName,
        CancellationToken cancellationToken = default)
    {
        string hashedPassword = passwordHasher.Generate(password);
        var user = User.Create(login, email, hashedPassword, firstName, lastName);

        await userRepository.AddAsync(user, cancellationToken);
    }

    public async Task<string> LoginAsync(
        string login,
        string password,
        CancellationToken cancellationToken = default)
    {
        try
        {
            User user = await userRepository.GetByLoginAsync(login, cancellationToken);
            bool verifyResult = passwordHasher.Verify(password, user.PasswordHash);

            if (!verifyResult)
                throw new BadAuthException("Login or password don't match");

            return jwtProvider.GenerateToken(user);
        }
        catch (BaseException)
        {
            throw new BadAuthException("Login or password don't match");
        }
    }
}