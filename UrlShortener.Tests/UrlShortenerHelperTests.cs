using System;
using System.Numerics;
using FluentAssertions;
using NUnit.Framework;
using UrlShortener.WebApi.Services.Helpers;

namespace UrlShortener.Tests
{
	public class UrlShortenerHelperTests
	{
        [TestCase("https://github.com/", "A3A12", 6)]
        [TestCase("https://www.google.com/", "DF660", 6)]
        public void Helper_Should_Properly_Hash_Values_With_Consistent_Outcome_For_XXH64(string url, string hash, int length)
		{
			UrlShortenerHelper helper = new UrlShortenerHelper();
			helper.HashUrl(url, length).Should().Be(hash);
		}

        [TestCase("malformed-test-url", false)]
        [TestCase("/192.168.1.1//--", false)]
        [TestCase("https://github.com/", true)]
        [TestCase("http://www.google.com/", true)]
        public void Helper_Url_Validator_Should_Validate_Accordingly(string url, Boolean result)
		{
            UrlShortenerHelper helper = new UrlShortenerHelper();
            helper.CheckUrlValidity(url).Should().Be(result);
        }
    }
}

