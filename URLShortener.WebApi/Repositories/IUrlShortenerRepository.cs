using UrlShortener.WebApi.Models.Data;

namespace UrlShortener.WebApi.Repositories
{
    public interface IUrlShortenerRepository
    {
        public Task<UrlShortenerModel?> GetUrlByShortenedUrl(string shortenedUrl);
        public Task<UrlShortenerModel?> GetUrlByOriginalUrl(string originalUrl);
        public Task<UrlShortenerModel> AddUrl(UrlShortenerModel model);
        public Task<List<UrlShortenerModel>> GetAllUrls();
    }
}
