using Microsoft.EntityFrameworkCore;

using MapsterMapper;

using Recipe.Core.Enums;
using Recipe.Core.Models;
using Recipe.Core.Exceptions;
using Recipe.Core.Repositories.Interfaces;
using Recipe.Data.Entities;
using Recipe.Data.Contexts;

namespace Recipe.Data.Repositories;

public class UsersRepository(
    RecipeContext dbContext,
    IMapper mapper) : IUsersRepository
{
    public async Task<User> GetById(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        var user = await dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == id, cancellationToken)
            ?? throw new NotFoundException($"User with id:\'{id}\' not found");

        return mapper.Map<User>(user);
    }

    public async Task<User> GetByLoginAsync(
        string login,
        CancellationToken cancellationToken = default)
    {
        var user = await dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Login == login, cancellationToken)
            ?? throw new NotFoundException($"User \'{login}\' not found");

        return mapper.Map<User>(user);
    }

    public async Task AddAsync(
        User user,
        CancellationToken cancellationToken = default)
    {
        await CheckAlreadyCreated(user);

        var userRole = await dbContext.Roles
            .SingleOrDefaultAsync(r => r.Id == (int)Role.User, cancellationToken)
            ?? throw new InvalidOperationException();

        var newUser = mapper.Map<UserEntity>(user);
        newUser.Roles = [userRole];

        await dbContext.Users.AddAsync(newUser);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task CheckAlreadyCreated(
        User user,
        CancellationToken cancellationToken = default)
    {
        var createdByLogin = await dbContext.Users
            .AnyAsync(u => u.Login == user.Login, cancellationToken);

        if (createdByLogin)
            throw new BadAuthException($"Login \'{user.Login}\' already created");

        var createdByEmail = await dbContext.Users
            .AnyAsync(u => u.Email == user.Email, cancellationToken);

        if (createdByEmail)
            throw new BadAuthException($"Email \'{user.Email}\' already used");
    }

    public async Task<HashSet<Permission>> GetUserPermissionsAsync(
        Guid userId,
        CancellationToken cancellationToken = default)
    {
        var roles = await dbContext.Users
            .Include(u => u.Roles)
            .ThenInclude(u => u.Permissions)
            .Where(u => u.Id == userId)
            .AsNoTracking()
            .Select(u => u.Roles)
            .ToListAsync(cancellationToken);

        var permissions = roles
            .SelectMany(r => r)
            .SelectMany(r => r.Permissions)
            .Select(p => (Permission)p.Id)
            .ToHashSet();

        return permissions;
    }
}