using TinyUrlGenerator.Interfaces;

namespace TinyUrlGenerator.Repositories
{
    public class UrlRepository : IUrlRepository
    {
        private readonly Dictionary<string, string> _shortToLongUrls = new Dictionary<string, string>();
        private readonly Dictionary<string, int> _clickCount = new Dictionary<string, int>();

        public void CreateUrlMapping(string shortUrl, string longUrl)
        {
            _shortToLongUrls[shortUrl] = longUrl;
            _clickCount[shortUrl] = 0;
        }

        public void DeleteUrlMapping(string shortUrl)
        {
            if (_shortToLongUrls.ContainsKey(shortUrl))
            {
                _shortToLongUrls.Remove(shortUrl);
                _clickCount.Remove(shortUrl);
            }
        }

        public string? GetLongUrl(string shortUrl)
        {
            if (_shortToLongUrls.TryGetValue(shortUrl, out var url))
            {
                _clickCount[shortUrl]++;
                return url;
            }
            return null;
        }

        public int GetClickCount(string shortUrl)
        {
            return _clickCount.TryGetValue(shortUrl, out var value) ? value : 0;
        }

        public bool ShortUrlExists(string shortUrl)
        {
            return _shortToLongUrls.ContainsKey(shortUrl);
        }
    }
}