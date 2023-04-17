using System;
using System.Numerics;
using FluentAssertions;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using UrlShortener.WebApi.Exceptions;
using UrlShortener.WebApi.Models.Data;
using UrlShortener.WebApi.Repositories;
using UrlShortener.WebApi.Services.Helpers;
using URLShortener.WebApi.Config;
using URLShortener.WebApi.Services;

namespace UrlShortener.Tests
{
	public class UrlShortenerServiceTests
	{
		private UrlShortenerHelper _helper;
		private UrlShortenerRepository _repository;
		private IOptions<UrlShortenerConfig> _config;
		private UrlShortenerService _service;

        public UrlShortenerServiceTests()
		{
			Populate.InsertData();
			_helper = new UrlShortenerHelper();
			_repository = new UrlShortenerRepository();
			_config = Options.Create<UrlShortenerConfig>(Populate.config);
			_service = new UrlShortenerService(_helper, _repository, _config);
        }

		[TestCase("https://github.com/", "A3A12")]
		public async Task Service_Should_Return_Correct_Original_Value(string originalUrl, string hashPath)
		{
			UrlShortenerModel result = await _service.GetOriginalUrl(hashPath);
			result.OriginalUrl.Should().Be(originalUrl);
		}

		[TestCase("non-existent-path")]
		public void Service_Should_Throw_An_Exception_If_It_Does_Not_Exist(string hashPath)
		{
            Func<Task> task = async () => await _service.GetOriginalUrl(hashPath);
            task.Should().ThrowAsync<UrlNotFoundException>();
        }

		[TestCase("https://www.google.com/", "DF660")]
		public async Task Service_Should_Properly_Shorten_Url(string url, string hashPath)
		{
            UrlShortenerModel result = await _service.ShortenUrl(url);
			result.ShortenedPath.Should().Be(hashPath);
        }

        [TestCase("https://malformed-url????&&&")]
        public void Shorten_Service_Should_Throw_An_Exception_If_Original_Url_Is_Malformed(string originalUrl)
		{
            Func<Task> task = async () => await _service.ShortenUrl(originalUrl);
            task.Should().ThrowAsync<UrlNotValidException>();
        }

        [TestCase("https://twitter.com/", "twitter")]
        public void Shorten_Service_Should_Throw_An_Exception_If_Custom_Url_Already_Exists(string originalUrl, string customUrl)
        {
            Func<Task> task = async () => await _service.ShortenUrl(originalUrl, customUrl);
            task.Should().ThrowAsync<PathAlreadyExistsException>();
        }
    }
}

