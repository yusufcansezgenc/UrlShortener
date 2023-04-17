namespace UrlShortener.WebApi.Services.Helpers
{
    public interface IUrlShortenerHelper
    {
        public Boolean CheckUrlValidity(string originalUrl);
        public string HashUrl(string url, int hashLength);
    }
}
