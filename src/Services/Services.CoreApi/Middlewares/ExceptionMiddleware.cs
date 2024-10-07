namespace devdeer.ListOfWork.Services.CoreApi.Middlewares
{
    using devdeer.ListOfWork.Logic.Common.Exceptions;
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
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    context.Response.ContentType = "application/json";
                    var errorResponse = JsonSerializer.Serialize(ex.Message);
                    await context.Response.WriteAsync(errorResponse);
                }
                if(ex is ArgumentException)
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    context.Response.ContentType = "application/json";
                    var errorResponse = JsonSerializer.Serialize(ex.Message);
                    await context.Response.WriteAsync(errorResponse);
                }
            }
        }
    }
}