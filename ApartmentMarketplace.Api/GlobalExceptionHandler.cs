using System.Net.Mime;
using ApartmentMarketplace.Domain.Common.Models;
using ApartmentMarketplace.Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.Formatters;

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
            NotFoundException notFoundException => (StatusCodes.Status404NotFound, notFoundException.Message),
            _ => (StatusCodes.Status500InternalServerError, "Something went wrong")
        };

        httpContext.Response.ContentType = MediaTypeNames.Application.Json;
        httpContext.Response.StatusCode = statusCode;

        ErrorResponse response = new()
        {
            StatusCode = statusCode,
            Message = errorMessage
        };

        await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);

        return true;
    }
}