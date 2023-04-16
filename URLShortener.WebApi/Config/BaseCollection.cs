using UrlShortener.WebApi.Models.Data;

namespace UrlShortener.WebApi.Config
{
    public static class BaseCollection
    {
        public static List<UrlShortenerModel> Data = new List<UrlShortenerModel>()
        {
            { new UrlShortenerModel { OriginalUrl = "test", ShortenedUrl = "shortened-test" } }
        };
    }
}
