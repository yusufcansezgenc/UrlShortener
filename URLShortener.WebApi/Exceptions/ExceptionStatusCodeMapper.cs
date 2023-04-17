using System.Net;

namespace UrlShortener.WebApi.Exceptions
{
    public static class ExceptionStatusCodeMapper
    {
        public static HttpStatusCode MapExceptions(Exception exception)
        {
            if (exception is PathAlreadyExistsException or 
                UrlNotValidException) return HttpStatusCode.BadRequest;
            if(exception is UrlNotFoundException) return HttpStatusCode.NotFound;

            return HttpStatusCode.InternalServerError;
        }
    }
}
