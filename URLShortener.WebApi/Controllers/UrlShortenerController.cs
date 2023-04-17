using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using UrlShortener.WebApi.Models.Data;
using URLShortener.WebApi.Config;
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
            return Ok(await _urlShortenerService.ShortenUrl(request.OriginalUrl, request.CustomPath));
        }

        [HttpPost]
        [Route("api/url/find-original")]
        public async Task<IActionResult> GetOriginalUrl([FromBody] UrlShortenerRequestModel request)
        {
            return Ok(await _urlShortenerService.GetOriginalUrl(request.CustomPath));
        }

        [HttpGet]
        [Route("api/url/find-all")]
        public async Task<IActionResult> GetAllUrls()
        {
            return Ok(await _urlShortenerService.GetAllUrls());
        }

        [HttpGet]
        [Route("{path}")]
        public async Task<IActionResult> RedirectUrl(string path)
        {
            UrlShortenerModel url = await _urlShortenerService.GetOriginalUrl(path);
            return Redirect(url.OriginalUrl);
        }
    }
}
