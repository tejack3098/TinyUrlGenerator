using TinyUrlGenerator.Interfaces;
using TinyUrlGenerator.Repositories;
using TinyUrlGenerator.Services;
using NUnit.Framework;
using TinyUrlGenerator.Utils;

namespace TinyUrlGenerator.UnitTests
{
    [TestFixture]
    public class UrlServiceTests
    {
        private IUrlRepository? _urlRepository;
        private IUrlService? _urlService;

        [SetUp]
        public void Initialize()
        {
            _urlRepository = new UrlRepository();
            _urlService = new UrlService(_urlRepository);
        }

        [Test]
        public void CreateShortURL_GenerateRandomShortURL()
        {
            // Arrange
            var longUrl = "https://www.mocklongurl.com";

            // Act
            var shortUrl = _urlService!.CreateShortUrl(longUrl);

            // Assert
            Assert.IsNotNull(shortUrl);
        }

        [Test]
        public void CreateShortURL_ProvideCustomShortURL()
        {
            // Arrange
            var longUrl = "https://www.mocklongurl.com";
            var customShortUrl = "customUrl123";

            // Act
            var shortUrl = _urlService!.CreateShortUrl(longUrl, customShortUrl);

            // Assert
            Assert.AreEqual(Constants.ShortUrlPrefix + customShortUrl, shortUrl);
        }

        [Test]
        public void CreateShortURL_ProvideCustomShortURL_CheckUrlDuplicateEntries()
        {
            // Arrange
            var longUrl = "https://www.mocklongurl.com";
            var customShortUrl = "customUrl123";

            // Act
            var shortUrl1 = _urlService!.CreateShortUrl(longUrl, customShortUrl);

            // Try again with same customShortUrl
            var shortUrl2 = _urlService!.CreateShortUrl(longUrl, customShortUrl);

            // Assert
            Assert.AreEqual(Constants.ShortUrlPrefix + customShortUrl, shortUrl1);
            Assert.AreEqual(Constants.DuplicateCustomUrl, shortUrl2);
        }

        [Test]
        public void DeleteShortUrl()
        {
            // Arrange
            var longUrl = "https://www.mocklongurl.com";
            var shortUrl = _urlService!.CreateShortUrl(longUrl);

            // Act
            _urlService!.DeleteShortUrl(shortUrl);

            // Assert
            var retrievedLongUrl = _urlService!.GetLongUrl(shortUrl);
            Assert.IsNull(retrievedLongUrl);
        }

        [Test]
        public void GetLongUrl()
        {
            // Arrange
            var longUrl = "https://www.mocklongurl.com";
            var shortUrl = _urlService!.CreateShortUrl(longUrl);

            // Act
            var retrievedLongUrl = _urlService!.GetLongUrl(shortUrl);

            // Assert
            Assert.AreEqual(longUrl, retrievedLongUrl);
        }

        [Test]
        public void GetClickCount()
        {
            // Arrange
            var longUrl = "https://www.mocklongurl.com";
            var shortUrl = _urlService!.CreateShortUrl(longUrl);

            // Act
            for (int i = 0; i < 5; i++)
            {
                 _urlService!.GetLongUrl(shortUrl);
            }
            var count = _urlService!.GetClickCount(shortUrl);
                
            // Assert
            Assert.AreEqual(5, count);
        }   
    }
}