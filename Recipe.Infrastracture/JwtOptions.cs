namespace Recipe.Infrastracture;

public class JwtOptions
{
    public string SecretKey { get; set; } = null!;

    public int ExpiresHours { get; set; }
}