namespace TinyUrlGenerator.Interfaces
{
    public interface IUrlService
    {
        string CreateShortUrl(string longUrl, string? customShortUrl = null);
        void DeleteShortUrl(string shortUrl);
        string? GetLongUrl(string shortUrl);
        int GetClickCount(string shortUrl);
    }
}