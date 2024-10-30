
namespace FeedBackApp.Helpers
{
    public static class SlugHelper
    {
        public static string GenerateSlug(string value)
        {
            return value
                .ToLowerInvariant()
                .Replace(" ", "-")
                .Replace("ö", "o")
                .Replace("ü", "u")
                .Replace("ş", "s")
                .Replace("ı", "i")
                .Replace("ç", "c")
                .Replace("ğ", "g")
                .Replace(",", "")
                .Replace(".", "")
                .Replace("'", "")
                .Replace("\"", "")
                .Replace(";", "")
                .Replace(":", "")
                .Replace("&", "")
                .Replace("?", "")
                .Replace("=", "")
                .Replace("/", "")
                .Replace("\\", "");
        }
    }
}
