namespace Recipe.Core.Exceptions;

public class BadAuthException : BaseException
{
    public BadAuthException()
    {
    }

    public BadAuthException(string? message)
        : base(message)
    {
    }

    public BadAuthException(string? message, Exception innerException)
        : base(message, innerException)
    {
    }
}
