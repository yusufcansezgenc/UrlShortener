namespace UrlShortener.WebApi.Exceptions
{
    public class UrlAlreadyExistsException : Exception
    {
        public UrlAlreadyExistsException(string message)
           : base(message)
        {

        }
    }
}
