namespace TinyUrlGenerator.Interfaces
{
    public interface IUrlRepository
    {
        void CreateUrlMapping(string shortUrl, string longUrl);
        void DeleteUrlMapping(string shortUrl);
        string? GetLongUrl(string shortUrl);
        int GetClickCount(string shortUrl);
        bool ShortUrlExists(string shortUrl);
    }
}