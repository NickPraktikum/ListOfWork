namespace devdeer.ListOfWork.Services.CoreApi.Middlewares
{
    using devdeer.ListOfWork.Logic.Common.Exceptions;
    using Microsoft.AspNetCore.Mvc;
    using System.Text.Json;
    /// <summary>
    /// A middleware intended to handle requests with exceptions from the logic.
    /// </summary>
    public class ExceptionMiddleware : IMiddleware
    {
        /// <inheritdoc />
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                if (ex is EntityNotFoundException)
                {
                    var problemDetails = new ProblemDetails
                    {
                        Type = "https://tools.ietf.org/html/rfc9110#section-15.5.5",
                        Title = "Not Found",
                        Status = StatusCodes.Status404NotFound,
                        Detail = ex.Message,
                    };
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    context.Response.ContentType = "application/json";
                    var errorResponse = JsonSerializer.Serialize(problemDetails);
                    await context.Response.WriteAsync(errorResponse);
                }
                if (ex is ArgumentException)
                {
                    var problemDetails = new ProblemDetails
                    {
                        Type = "https://tools.ietf.org/html/rfc9110#section-15.5.1",
                        Title = "Bad Request",
                        Status = StatusCodes.Status400BadRequest,
                        Detail = ex.Message,
                    };
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    context.Response.ContentType = "application/json";
                    var errorResponse = JsonSerializer.Serialize(problemDetails);
                    await context.Response.WriteAsync(errorResponse);
                }
            }
        }
    }
}