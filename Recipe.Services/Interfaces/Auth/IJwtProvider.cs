using Recipe.Core.Models;

namespace Recipe.Services.Interfaces.Auth;

public interface IJwtProvider
{
    string GenerateToken(User user);
}
