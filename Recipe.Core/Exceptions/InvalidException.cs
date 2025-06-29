namespace Recipe.Core.Exceptions;

public class InvalidException : BaseException
{
    public InvalidException()
    {
    }

    public InvalidException(string? message)
        : base(message)
    {
    }

    public InvalidException(string? message, Exception innerException)
        : base(message, innerException)
    {
    }
}
