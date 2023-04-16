using Newtonsoft.Json;
using Serilog;
using System.Net;

namespace UrlShortener.WebApi.Exceptions
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                var code = ExceptionStatusCodeMapper.MapExceptions(exception);
                //logging can be implemented here
                await HandleExceptionAsync(context, exception, code);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, System.Exception exception, HttpStatusCode exceptionCode)
        {
            if (exception == null) return;

            await WriteExceptionAsync(context, exception, exceptionCode).ConfigureAwait(false);
        }

        private static async Task WriteExceptionAsync(HttpContext context, Exception exception, HttpStatusCode code)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)code;

            var bodyText = JsonConvert.SerializeObject(new
            {
                error = new
                {
                    exception = exception.GetType().Name,
                    message = exception.Message,
                }
            });

            await response.WriteAsync(bodyText).ConfigureAwait(false);
        }
    }
}