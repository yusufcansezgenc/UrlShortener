using UrlShortener.WebApi.Models.Data;

namespace URLShortener.WebApi.Services
{
    public interface IUrlShortenerService
    {
        public Task<UrlShortenerModel> ShortenUrl(string originalUrl);
        public Task<UrlShortenerModel> ShortenUrl(string originalUrl, string customUrl);
        public Task<UrlShortenerModel> GetOriginalUrl(string shortenedUrl);
        public Task<List<UrlShortenerModel>> GetAllUrls();
    }
}
