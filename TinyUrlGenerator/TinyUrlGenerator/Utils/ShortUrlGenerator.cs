using System.Security.Cryptography;
using System.Text;

namespace TinyUrlGenerator.Utils
{
    public static class ShortUrlGenerator
    {
        public static string GenerateShortUrl(string longUrl)
        {
            // Generate a unique MD5 hash for the long URL.
            var hash = GenerateMd5Hash(longUrl);

            // Encode the 128-bit hash in Base62.
            var shortUrl = Base62Encode(hash);

            return Constants.ShortUrlPrefix + shortUrl;
        }

        private static string GenerateMd5Hash(string input)
        {
            using MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Convert the MD5 hash to a hexadecimal string.
            StringBuilder sb = new StringBuilder();
            foreach (var t in hashBytes)
            {
                sb.Append(t.ToString("X2"));
            }

            return sb.ToString();
        }

        private static string Base62Encode(string input)
        {
            ulong value = 0;

            foreach (var c in input)
            {
                int index = Constants.Chars.IndexOf(c);
                if (index >= 0)
                {
                    value = (value * 62) + (ulong)index;
                }
            }

            var result = new StringBuilder();
            const int desiredLength = 8; // Set the desired length

            while (value > 0 && result.Length < desiredLength)
            {
                result.Insert(0, Constants.Chars[(int)(value % 62)]);
                value /= 62;
            }

            // Pad with '0' to ensure the desired length.
            while (result.Length < desiredLength)
            {
                result.Insert(0, '0');
            }

            return result.ToString();
        }
    }
}