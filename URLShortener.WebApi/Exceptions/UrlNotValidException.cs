namespace UrlShortener.WebApi.Exceptions
{
    public class UrlNotValidException : Exception
    {
        public UrlNotValidException(string message)
            : base(message)
        {

        }
    }
}
