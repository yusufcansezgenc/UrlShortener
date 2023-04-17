using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.Extensions.Options;
using System.IO;
using System.Security.Policy;
using UrlShortener.WebApi.Exceptions;
using UrlShortener.WebApi.Models.Data;
using UrlShortener.WebApi.Repositories;
using UrlShortener.WebApi.Services.Helpers;
using URLShortener.WebApi.Config;

namespace URLShortener.WebApi.Services
{
    public class UrlShortenerService : IUrlShortenerService
    {
        private IUrlShortenerHelper _urlShortenerHelper;
        private IUrlShortenerRepository _urlShortenerRepository;
        private UrlShortenerConfig _urlShortenerConfig;

        public UrlShortenerService(IUrlShortenerHelper urlShortenerHelper,
            IUrlShortenerRepository urlShortenerRepository,
            IOptions<UrlShortenerConfig> options)
        {
            _urlShortenerHelper = urlShortenerHelper;
            _urlShortenerRepository = urlShortenerRepository;
            _urlShortenerConfig = options.Value;
        }

        public async Task<UrlShortenerModel> GetOriginalUrl(string shortenedUrl)
        {
            UrlShortenerModel? result = await _urlShortenerRepository.GetUrlByShortenedUrl(shortenedUrl);

            return result ?? throw new UrlNotFoundException("Unable to find url " + shortenedUrl);
        }

        public async Task<UrlShortenerModel> ShortenUrl(string originalUrl)
        {
            UrlShortenerModel? result = await _urlShortenerRepository.GetUrlByOriginalUrl(originalUrl);
            UrlShortenerModel url;

            if (result != null)
            {
                //return already existing result
                return result;
            }
            else
            {
                string shortenedPath = _urlShortenerHelper.HashUrl(originalUrl, _urlShortenerConfig.HashLength);

                if (_urlShortenerHelper.CheckUrlValidity(originalUrl))
                {
                    url = new UrlShortenerModel { OriginalUrl = originalUrl, ShortenedPath = shortenedPath };
                    return await _urlShortenerRepository.AddUrl(url);
                }
                else
                {
                    throw new UrlNotValidException("Requested URL: " + originalUrl + " is not valid.");
                }
            }
            
        }

        public async Task<UrlShortenerModel> ShortenUrl(string originalUrl, string customUrl)
        {
            UrlShortenerModel? result = await _urlShortenerRepository.GetUrlByShortenedUrl(customUrl);
            UrlShortenerModel url;

            if (result != null)
            {
                throw new PathAlreadyExistsException("Custom path: " + result.ShortenedPath + " already exists");
            }
            else
            {
                if (_urlShortenerHelper.CheckUrlValidity(originalUrl))
                {
                    url = new UrlShortenerModel { 
                        OriginalUrl = originalUrl, 
                        ShortenedPath = customUrl
                    };
                    return await _urlShortenerRepository.AddUrl(url);
                }
                else
                {
                    throw new UrlNotValidException("Requested URL: " + originalUrl + " is not valid.");
                }
            }
        }

        public async Task<List<UrlShortenerModel>> GetAllUrls()
        {
            return await _urlShortenerRepository.GetAllUrls();
        }

    }
}
