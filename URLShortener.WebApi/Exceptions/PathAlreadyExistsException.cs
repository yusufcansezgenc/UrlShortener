namespace UrlShortener.WebApi.Exceptions
{
    public class PathAlreadyExistsException : Exception
    {
        public PathAlreadyExistsException(string message)
           : base(message)
        {

        }
    }
}
