namespace UrlShortener.WebApi.Services.Helpers
{
    public interface IUrlShortenerHelper
    {
        public string SplitUrl(string originalUrl);
        public Boolean CheckUrlValidity(string originalUrl);
        public string HashPath(string path, int hashLength);
    }
}
