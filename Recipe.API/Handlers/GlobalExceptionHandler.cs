using System.Net;
using System.Security;
using System.Text.Json;
using System.Transactions;

using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Recipe.API.Handlers;

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    : IExceptionHandler
{
    private const string ExceptionMessage = 
        "An error occurred when executing the request";

    private readonly Type[] NotDetailExceptions =
        [
            typeof(SqlException),
            typeof(DbUpdateException),
            typeof(SecurityException),
            typeof(OutOfMemoryException),
            typeof(TransactionException),
            typeof(NotSupportedException),
            typeof(StackOverflowException),
            typeof(InvalidOperationException),
            typeof(UnauthorizedAccessException),
            typeof(DbUpdateConcurrencyException),
            typeof(InternalBufferOverflowException),
        ];

    private readonly Type[] CanceledExceptions =
        [
            typeof(TaskCanceledException),
            typeof(OperationCanceledException),
        ];

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        logger.LogError(exception.Message);

        if (CanceledExceptions.Contains(exception.GetType()))
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.RequestTimeout;
            await httpContext.Response.WriteAsync(
                JsonSerializer.Serialize(new
                {
                    Message = "Request canceled or timed out",
                    Details = "The operation was aborted"
                }),
                cancellationToken);
            return true;
        }

        var errorInfo = new
        {
            Message = ExceptionMessage,
            // todo while it's debug
            Details = !NotDetailExceptions.Contains(exception.GetType()) 
                ? exception.Message 
                : "Not details",
        };

        httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        var responce = JsonSerializer.Serialize(errorInfo, new JsonSerializerOptions
        {
            WriteIndented = true,
        });

        await httpContext.Response.WriteAsync(responce, cancellationToken);

        return true;
    }
}
