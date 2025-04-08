﻿using Recipe.Core.Models;
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
        string hashedPassword = passwordHasher.Generate(password);
        var user = User.Create(login, email, hashedPassword, firstName, lastName);

        await userRepository.AddAsync(user);
    }

    public async Task<string> LoginAsync(string login, string password)
    {
        try
        {
            User user = await userRepository.GetByLoginAsync(login);
            bool verifyResult = passwordHasher.Verify(password, user.PasswordHash);

            if (!verifyResult)
                throw new BadAuthException();

            return jwtProvider.GenerateToken(user);
        }
        catch (BaseException) 
        {
            throw new BadAuthException("Login or password don't match");
        }
    }
}