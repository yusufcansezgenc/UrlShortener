using Microsoft.AspNetCore.Mvc;
using URLShortener.WebApi.Models.Web;
using URLShortener.WebApi.Services;

namespace UrlShortener.WebApi.Controllers
{
    public class UrlShortenerController : ControllerBase
    {
        private IUrlShortenerService _urlShortenerService;
        public UrlShortenerController (IUrlShortenerService urlShortenerService) 
        {
            _urlShortenerService = urlShortenerService;
        }

        [HttpPost]
        [Route("api/url/shorten")]
        public async Task<IActionResult> ShortenUrl([FromBody] UrlShortenerRequestModel request)
        {
            return Ok(await _urlShortenerService.ShortenUrl(request.OriginalUrl));
        }

        [HttpPost]
        [Route("api/url/shorten-custom")]
        public async Task<IActionResult> ShortenUrlCustom([FromBody] UrlShortenerRequestModel request)
        {
            return Ok(await _urlShortenerService.ShortenUrl(request.OriginalUrl, request.CustomUrl));
        }

        [HttpPost]
        [Route("api/url/find-original")]
        public async Task<IActionResult> GetOriginalUrl([FromBody] UrlShortenerRequestModel request)
        {
            return Ok(await _urlShortenerService.GetOriginalUrl(request.CustomUrl));
        }

        [HttpGet]
        [Route("api/url/find-all")]
        public async Task<IActionResult> GetAllUrls()
        {
            return Ok(await _urlShortenerService.GetAllUrls());
        }
    }
}
