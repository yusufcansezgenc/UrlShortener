using System;
using UrlShortener.WebApi.Config;
using UrlShortener.WebApi.Models.Data;
using URLShortener.WebApi.Config;

namespace UrlShortener.Tests
{
	public class Populate
	{
		public static UrlShortenerConfig config = new UrlShortenerConfig
		{
			HashLength = 6,
			ShortenedHost = "http://127.0.0.1::5065/"
        };

        public static void InsertData()
		{
			List<UrlShortenerModel> data = new List<UrlShortenerModel>
			{
                { new UrlShortenerModel { OriginalUrl = "https://github.com/", ShortenedPath = "A3A12" } },
                { new UrlShortenerModel { OriginalUrl = "https://twitter.com/", ShortenedPath = "twitter" } }
            };

			BaseCollection.Data.AddRange(data);
		}

	}
}

