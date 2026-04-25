using System.Text;

namespace TestNugetPkg.Core.Helpers;

#pragma warning disable CS1591

/// <summary>
/// Helper class for encoding/decoding.
/// </summary>
public static class EncodingHelper
{
    /// <summary>Encodes a string to Base64.</summary>
    public static string ToBase64(string input) => Convert.ToBase64String(Encoding.UTF8.GetBytes(input));

    /// <summary>Decodes a Base64 string.</summary>
    public static string FromBase64(string base64) => Encoding.UTF8.GetString(Convert.FromBase64String(base64));

    /// <summary>URL encodes a string.</summary>
    public static string UrlEncode(string input) => Uri.EscapeDataString(input);

    /// <summary>URL decodes a string.</summary>
    public static string UrlDecode(string input) => Uri.UnescapeDataString(input);

    /// <summary>HTML encodes a string.</summary>
    public static string HtmlEncode(string input)
    {
        return input.Replace("&", "&amp;") // Must be replaced first to avoid double encoding
                 .Replace("<", "&lt;") // Must be replaced before ">" to avoid double encoding
                 .Replace(">", "&gt;") // Must be replaced before "<" to avoid double encoding
                 .Replace("\"", "&quot;") // Must be replaced before "'" to avoid double encoding
                 .Replace("'", "&#39;"); // Must be replaced last to avoid double encoding
    }

    /// <summary>HTML decodes a string.</summary>
    public static string HtmlDecode(string input)
    {
        return input.Replace("&amp;", "&") // Must be replaced first to avoid double decoding
                 .Replace("&lt;", "<") // Must be replaced before "&gt;" to avoid double decoding
                 .Replace("&gt;", ">") // Must be replaced before "&lt;" to avoid double decoding
                 .Replace("&quot;", "\"") // Must be replaced before "&#39;" to avoid double decoding
                 .Replace("&#39;", "'"); // Must be replaced last to avoid double decoding
    }
}