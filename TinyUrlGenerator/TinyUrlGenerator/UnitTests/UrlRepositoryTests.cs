using NUnit.Framework;
using TinyUrlGenerator.Interfaces;
using TinyUrlGenerator.Repositories;
using TinyUrlGenerator.Utils;

namespace TinyUrlGenerator.UnitTests
{
    public class UrlRepositoryTests
    {
        private IUrlRepository? _urlRepository;

        [SetUp]
        public void Initialize()
        {
            _urlRepository = new UrlRepository();
        }

        [Test]
        public void CreateUrlMapping()
        {
            // Arrange
            var shortUrl = Constants.ShortUrlPrefix + "customUrl123";
            var longUrl = "https://www.mocklongurl.com";

            // Act
            _urlRepository!.CreateUrlMapping(shortUrl, longUrl);
            var retrievedLongUrl = _urlRepository!.GetLongUrl(shortUrl);

            // Assert
            Assert.AreEqual(longUrl, retrievedLongUrl);
        }

        [Test]
        public void DeleteUrlMapping()
        {
            // Arrange
            var shortUrl = Constants.ShortUrlPrefix + "customUrl123";
            var longUrl = "https://www.mocklongurl.com";
            _urlRepository!.CreateUrlMapping(shortUrl, longUrl);

            // Act
            _urlRepository!.DeleteUrlMapping(shortUrl);
            var retrievedLongUrl = _urlRepository!.GetLongUrl(shortUrl);

            // Assert
            Assert.IsNull(retrievedLongUrl);
        }

        [Test]
        public void GetClickCount()
        {
            // Arrange
            var shortUrl = Constants.ShortUrlPrefix + "customUrl123";
            var longUrl = "https://www.mocklongurl.com";

            // Act
            _urlRepository!.CreateUrlMapping(shortUrl, longUrl);
            _urlRepository!.GetLongUrl(shortUrl);

            var count = _urlRepository!.GetClickCount(shortUrl);

            // Assert
            Assert.AreEqual(1, count);
        }
    }
}