using UrlShortener.WebApi.Config;
using UrlShortener.WebApi.Models.Data;

namespace UrlShortener.WebApi.Repositories
{
    public class UrlShortenerRepository : IUrlShortenerRepository
    {
        public async Task<UrlShortenerModel?> GetUrlByShortenedUrl(string shortenedUrl)
        {
            return await Task.Run(() => BaseCollection.Data.Find(data => data.ShortenedUrl == shortenedUrl));
        }

        public async Task<UrlShortenerModel> AddUrl(UrlShortenerModel model)
        {
            await Task.Run(() => BaseCollection.Data.Add(model));
            return model;
        }

        public async Task<UrlShortenerModel?> GetUrlByOriginalUrl(string originalUrl)
        {
            return await Task.Run(() => BaseCollection.Data.Find(data => data.OriginalUrl == originalUrl));
        }

        public async Task<List<UrlShortenerModel>> GetAllUrls()
        {
            return await Task.Run(() => BaseCollection.Data);
        }
    }
}
