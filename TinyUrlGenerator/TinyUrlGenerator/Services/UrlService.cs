using TinyUrlGenerator.Interfaces;
using TinyUrlGenerator.Utils;

namespace TinyUrlGenerator.Services
{
    public class UrlService : IUrlService
    {
        private readonly IUrlRepository _urlRepository;

        public UrlService(IUrlRepository repository)
        {
            _urlRepository = repository;
        }

        public string CreateShortUrl(string longUrl, string? customShortUrl = null)
        {
            if (string.IsNullOrWhiteSpace(customShortUrl))
            {
                customShortUrl = ShortUrlGenerator.GenerateShortUrl(longUrl);
            }
            else
            {
                customShortUrl = Constants.ShortUrlPrefix + customShortUrl;
            }

            if (_urlRepository.ShortUrlExists(customShortUrl))
            {
                Console.WriteLine("\nCustom short URL already in use. Please try another one.");

                return Constants.DuplicateCustomUrl;
            }

            _urlRepository.CreateUrlMapping(customShortUrl, longUrl);
            return customShortUrl;
        }

        public void DeleteShortUrl(string shortUrl)
        {
            _urlRepository.DeleteUrlMapping(shortUrl);
        }

        public string? GetLongUrl(string shortUrl)
        {
            return _urlRepository.GetLongUrl(shortUrl);
        }

        public int GetClickCount(string shortUrl)
        {
            return _urlRepository.GetClickCount(shortUrl);
        }
    }
}