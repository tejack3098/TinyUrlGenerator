using TinyUrlGenerator.Interfaces;
using TinyUrlGenerator.Repositories;
using TinyUrlGenerator.Services;
using TinyUrlGenerator.Utils;

IUrlRepository repository = new UrlRepository();
IUrlService urlService = new UrlService(repository);

while (true)
{
    Console.WriteLine("\n\nTinyURL Menu:");
    Console.WriteLine("1. Create Short URL");
    Console.WriteLine("2. Delete Short URL");
    Console.WriteLine("3. Get Long URL");
    Console.WriteLine("4. Get Click Count");
    Console.WriteLine("5. Exit\n");
    Console.Write("Choose an option: ");

    if (int.TryParse(Console.ReadLine(), out int choice))
    {
        switch (choice)
        {
            case 1:
                Console.Write("Enter a long URL: ");
                var longUrl = Console.ReadLine();
                if (longUrl != null)
                {
                    Console.Write("Enter a custom short URL (leave empty for random): ");
                    var customShortUrl = Console.ReadLine();
                    var shortUrl = urlService.CreateShortUrl(longUrl, customShortUrl);

                    if (!string.Equals(shortUrl, Constants.DuplicateCustomUrl))
                    {
                        Console.WriteLine($"\nShort URL created: {shortUrl}");
                    }
                }
                else
                {
                    Console.WriteLine("\nInvalid input. Please provide a valid long URL.");
                }
                break;
            case 2:
                Console.Write("Enter the short URL to delete: ");
                var deleteShortUrl = Console.ReadLine();
                if (deleteShortUrl != null)
                {
                    urlService.DeleteShortUrl(deleteShortUrl);
                    Console.WriteLine($"\nShort URL '{deleteShortUrl}' deleted.");
                }
                else
                {
                    Console.WriteLine("\nInvalid input. Please provide a valid short URL.");
                }
                break;
            case 3:
                Console.Write("Enter the short URL to get the long URL: ");
                var getLongUrl = Console.ReadLine();
                if (getLongUrl != null)
                {
                    var longUrlResult = urlService.GetLongUrl(getLongUrl);
                    Console.WriteLine($"\nLong URL: {longUrlResult}");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please provide a valid short URL.");
                }
                break;
            case 4:
                Console.Write("Enter the short URL to get the click count: ");
                var clickCountUrl = Console.ReadLine();
                if (clickCountUrl != null)
                {
                    var count = urlService.GetClickCount(clickCountUrl);
                    Console.WriteLine($"\nClick Count: {count}");
                }
                else
                {
                    Console.WriteLine("\nInvalid input. Please provide a valid short URL.");
                }
                break;
            case 5:
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    }
    else
    {
        Console.WriteLine("\nInvalid input. Please enter a number.");
    }
}