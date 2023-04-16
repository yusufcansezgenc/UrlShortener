namespace UrlShortener.WebApi.Exceptions
{
    public class UrlNotFoundException : Exception
    {
        public UrlNotFoundException(string message)
            : base(message)
        {

        }
    }
}
