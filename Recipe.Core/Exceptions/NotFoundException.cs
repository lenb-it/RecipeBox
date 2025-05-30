﻿namespace Recipe.Core.Exceptions;

public class NotFoundException : BaseException
{
    public NotFoundException()
    {
    }

    public NotFoundException(string? message)
        : base(message)
    {
    }

    public NotFoundException(string? message, Exception innerException)
        :base(message, innerException)
    {
    }
}
