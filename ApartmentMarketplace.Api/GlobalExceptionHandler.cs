using ApartmentMarketplace.Domain.Common.Models;
using ApartmentMarketplace.Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace ApartmentMarketplace.Api;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        var (statusCode, errorMessage) = exception switch
        {
            NotFoundException notFoundException => (404, notFoundException.Message),
            _ => (500, "Something went wrong")
        };

        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = statusCode;

        var response = new ErrorResponse
        {
            StatusCode = statusCode,
            Message = errorMessage
        };

        await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);

        return true;
    }
}