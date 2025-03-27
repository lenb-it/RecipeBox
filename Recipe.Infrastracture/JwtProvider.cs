using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using Recipe.Core.Models;
using Recipe.Services.Interfaces.Auth;
using Recipe.Infrastracture.Constants;

namespace Recipe.Infrastracture;

public class JwtProvider : IJwtProvider
{
    private readonly JwtOptions _options;

    public JwtProvider(IOptions<JwtOptions> options)
    {
        _options = options.Value;
    }

    public string GenerateToken(User user)
    {
        var claims = new Claim[]
        {
            new(CookieConstants.UserId, user.Id.ToString()),
        };

        var signingCreadentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)),
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: claims,
            signingCredentials: signingCreadentials,
            expires: DateTime.UtcNow.AddHours(_options.ExpiresHours));

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
