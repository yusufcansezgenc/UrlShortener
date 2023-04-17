using Microsoft.Extensions.Options;
using System.IO;
using System.IO.Hashing;
using UrlShortener.WebApi.Exceptions;
using URLShortener.WebApi.Config;

namespace UrlShortener.WebApi.Services.Helpers
{
    public class UrlShortenerHelper : IUrlShortenerHelper
    {
        public string HashUrl(string url, int hashLength)
        {
            byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(url);
            byte[] hashBytes = XxHash64.Hash(inputBytes);

            string result = Convert.ToHexString(hashBytes);

            return result.Substring(0, hashLength - 1);
        }

        public Boolean CheckUrlValidity(string originalUrl)
        {
            return (Uri.IsWellFormedUriString(originalUrl, UriKind.Absolute));
        }
    }
}
