﻿namespace URLShortener.WebApi.Models.Web
{
    public class UrlShortenerRequestModel
    {
        public string OriginalUrl { get; set; }
        public string CustomPath { get; set; }
    }
}
