using GymApi.Exceptions;
using System.Net;
using System.Text.Json;
using KeyNotFoundException = GymApi.Exceptions.KeyNotFoundException;
using NotImplementedException = GymApi.Exceptions.NotImplementedException;

namespace GymApi.CustomMiddleware
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public GlobalExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context , ex);
            }
        }
        public static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            HttpStatusCode statusCode;
            string message = "";

            var exceptionType = ex.GetType();
            if (exceptionType == typeof(BadRequestException))
            {
                statusCode = HttpStatusCode.BadRequest;
                message = ex.Message;
            }
            else if (exceptionType == typeof(KeyNotFoundException))
            {
                statusCode = HttpStatusCode.NotFound;
                message = ex.Message;
            }
            else if (exceptionType == typeof(NotAuthorizedAccessException))
            {
                statusCode = HttpStatusCode.Unauthorized;
                message = ex.Message;
            }else if (exceptionType == typeof(NotFoundException))
            {
                statusCode = HttpStatusCode.NotFound;
                message = ex.Message;
            }else if (exceptionType == typeof(NotImplementedException))
            {
                statusCode = HttpStatusCode.NotImplemented;
                message = ex.Message;
            }else if (exceptionType == typeof(NullException))
            {
                statusCode = HttpStatusCode.InternalServerError;
                message = ex.Message;
            }
            else
            {
                statusCode = HttpStatusCode.InternalServerError;
                message = ex.Message;
            }
            var ExceptionResult = JsonSerializer.Serialize(new{ status = statusCode, error = message });
            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = "application/json";
           return context.Response.WriteAsync(ExceptionResult);
        }
    }
}
