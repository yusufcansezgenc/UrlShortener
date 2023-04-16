namespace UrlShortener.WebApi.Models.Data
{
    public class UrlShortenerModel
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string OriginalUrl { get; set; }
        public string ShortenedUrl { get; set; }
    }
}
