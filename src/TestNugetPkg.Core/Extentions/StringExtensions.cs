namespace TestNugetPkg.Core.Extensions;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

/// <summary>
/// Provides string extension methods for converting strings between different case formats.
/// Provides extension methods for working with strings.
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Converts a string to PascalCase format.
    /// </summary>
    /// <param name="value">The string to convert.</param>
    /// <returns>The string in PascalCase format.</returns>
    /// <example>
    /// <code>
    /// string result = "hello_world".ToPascalCase(); // Returns "HelloWorld"
    /// </code>
    /// </example>
    public static string ToPascalCase(this string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return value;
        }

        var words = SplitOnSpecialChars(value);
        if (words.Length == 0)
        {
            return value;
        }

        var result = new char[value.Length];
        var resultIndex = 0;

        for (var i = 0; i < words.Length; i++)
        {
            var word = words[i];
            if (word.Length > 0)
            {
                result[resultIndex++] = char.ToUpper(word[0]);
                for (var j = 1; j < word.Length; j++)
                {
                    result[resultIndex++] = char.ToLower(word[j]);
                }
            }
        }

        return new string(result, 0, resultIndex);
    }

    /// <summary>
    /// Converts a string to camelCase format.
    /// </summary>
    /// <param name="value">The string to convert.</param>
    /// <returns>The string in camelCase format.</returns>
    /// <example>
    /// <code>
    /// string result = "HelloWorld".ToCamelCase(); // Returns "helloWorld"
    /// </code>
    /// </example>
    public static string ToCamelCase(this string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return value;
        }

        var pascal = value.ToPascalCase();
        if (pascal.Length == 0)
        {
            return pascal;
        }

        return char.ToLower(pascal[0]) + pascal[1..];
    }

    /// <summary>
    /// Converts a string to snake_case format.
    /// </summary>
    /// <param name="value">The string to convert.</param>
    /// <returns>The string in snake_case format.</returns>
    /// <example>
    /// <code>
    /// string result = "HelloWorld".ToSnakeCase(); // Returns "hello_world"
    /// </code>
    /// </example>
    public static string ToSnakeCase(this string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return value;
        }

        var words = SplitOnSpecialChars(value);
        return string.Join("_", words.Select(w => w.ToLower()));
    }

    /// <summary>
    /// Converts a string to kebab-case format.
    /// </summary>
    /// <param name="value">The string to convert.</param>
    /// <returns>The string in kebab-case format.</returns>
    /// <example>
    /// <code>
    /// string result = "HelloWorld".ToKebabCase(); // Returns "hello-world"
    /// </code>
    /// </example>
    public static string ToKebabCase(this string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return value;
        }

        var words = SplitOnSpecialChars(value);
        return string.Join("-", words.Select(w => w.ToLower()));
    }

    /// <summary>
    /// Converts a string to Train-Case format (each word capitalized, separated by dashes).
    /// </summary>
    /// <param name="value">The string to convert.</param>
    /// <returns>The string in Train-Case format.</returns>
    /// <example>
    /// <code>
    /// string result = "helloWorld".ToTrainCase(); // Returns "Hello-World"
    /// </code>
    /// </example>
    public static string ToTrainCase(this string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return value;
        }

        var words = SplitOnSpecialChars(value);
        return string.Join("-", words.Select(w => char.ToUpper(w[0]) + w[1..].ToLower()));
    }

    /// <summary>
    /// Converts a string to CONSTANT_CASE format (uppercase snake_case).
    /// </summary>
    /// <param name="value">The string to convert.</param>
    /// <returns>The string in CONSTANT_CASE format.</returns>
    /// <example>
    /// <code>
    /// string result = "helloWorld".ToConstantCase(); // Returns "HELLO_WORLD"
    /// </code>
    /// </example>
    public static string ToConstantCase(this string value)
    {
        return value.ToSnakeCase().ToUpper();
    }

    /// <summary>
    /// Converts a string to Title Case format (each word capitalized).
    /// </summary>
    /// <param name="value">The string to convert.</param>
    /// <returns>The string in Title Case format.</returns>
    /// <example>
    /// <code>
    /// string result = "hello world".ToTitleCase(); // Returns "Hello World"
    /// </code>
    /// </example>
    public static string ToTitleCase(this string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return value;
        }

        var words = SplitOnSpecialChars(value);
        return string.Join(" ", words.Select(w => char.ToUpper(w[0]) + w[1..].ToLower()));
    }

    /// <summary>
    /// Checks if a string is null, empty, or whitespace only.
    /// </summary>
    /// <param name="value">The string to check.</param>
    /// <returns>True if null, empty, or whitespace.</returns>
    public static bool IsBlank(this string? value)
    {
        return string.IsNullOrWhiteSpace(value);
    }

    /// <summary>
    /// Checks if a string has content (not null, empty, or whitespace).
    /// </summary>
    /// <param name="value">The string to check.</param>
    /// <returns>True if has content.</returns>
    public static bool IsNotBlank(this string? value)
    {
        return !string.IsNullOrWhiteSpace(value);
    }

    /// <summary>
    /// Returns the string or a default value if null or empty.
    /// </summary>
    /// <param name="value">The string.</param>
    /// <param name="defaultValue">The default value.</param>
    /// <returns>The string or default.</returns>
    public static string OrDefault(this string? value, string defaultValue = "")
    {
        return string.IsNullOrEmpty(value) ? defaultValue : value;
    }

    /// <summary>
    /// Truncates a string to the specified length.
    /// </summary>
    /// <param name="value">The string.</param>
    /// <param name="maxLength">Maximum length.</param>
    /// <param name="suffix">Suffix to append if truncated.</param>
    /// <returns>The truncated string.</returns>
    public static string Truncate(this string value, int maxLength, string suffix = "...")
    {
        if (string.IsNullOrEmpty(value) || value.Length <= maxLength)
        {
            return value;
        }

        return value[..(maxLength - suffix.Length)] + suffix;
    }

    /// <summary>
    /// Reverses a string.
    /// </summary>
    /// <param name="value">The string.</param>
    /// <returns>The reversed string.</returns>
    public static string Reverse(this string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return value;
        }

        var chars = value.ToCharArray();
        Array.Reverse(chars);
        return new string(chars);
    }

    /// <summary>
    /// Returns the leftmost characters of a string.
    /// </summary>
    /// <param name="value">The string.</param>
    /// <param name="count">Number of characters.</param>
    /// <returns>The leftmost characters.</returns>
    public static string Left(this string value, int count)
    {
        if (string.IsNullOrEmpty(value))
        {
            return value;
        }

        return value[..Math.Min(count, value.Length)];
    }

    /// <summary>
    /// Returns the rightmost characters of a string.
    /// </summary>
    /// <param name="value">The string.</param>
    /// <param name="count">Number of characters.</param>
    /// <returns>The rightmost characters.</returns>
    public static string Right(this string value, int count)
    {
        if (string.IsNullOrEmpty(value))
        {
            return value;
        }

        var start = Math.Max(0, value.Length - count);
        return value[start..];
    }

    /// <summary>
    /// Returns the string with leading/trailing whitespace removed and inner whitespace normalized to single spaces.
    /// </summary>
    /// <param name="value">The string.</param>
    /// <returns>The normalized string.</returns>
    public static string NormalizeWhitespace(this string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return string.Empty;
        }

        return string.Join(" ", value.Split(new[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries));
    }

    /// <summary>
    /// Repeats the string specified number of times.
    /// </summary>
    /// <param name="value">The string.</param>
    /// <param name="count">Number of times to repeat.</param>
    /// <returns>The repeated string.</returns>
    public static string Repeat(this string value, int count)
    {
        if (string.IsNullOrEmpty(value) || count <= 0)
        {
            return string.Empty;
        }

        return string.Concat(Enumerable.Repeat(value, count));
    }

    /// <summary>
    /// Pads the string to the left with the specified character.
    /// </summary>
    /// <param name="value">The string.</param>
    /// <param name="totalWidth">Total width.</param>
    /// <param name="paddingChar">Character to pad with.</param>
    /// <returns>The padded string.</returns>
    public static string PadLeft(this string value, int totalWidth, char paddingChar = ' ')
    {
        if (value is null)
        {
            return string.Empty.PadLeft(totalWidth, paddingChar);
        }

        return value.PadLeft(totalWidth, paddingChar);
    }

    /// <summary>
    /// Pads the string to the right with the specified character.
    /// </summary>
    /// <param name="value">The string.</param>
    /// <param name="totalWidth">Total width.</param>
    /// <param name="paddingChar">Character to pad with.</param>
    /// <returns>The padded string.</returns>
    public static string PadRight(this string value, int totalWidth, char paddingChar = ' ')
    {
        if (value is null)
        {
            return string.Empty.PadRight(totalWidth, paddingChar);
        }

        return value.PadRight(totalWidth, paddingChar);
    }

    // Splits a string into words based on non-alphanumeric characters and camelCase transitions.
    private static string[] SplitOnSpecialChars(string value)
    {
        var words = new List<string>();
        var current = new System.Text.StringBuilder();
        var lastChar = '\0';

        // Iterate through each character in the string
        for (var i = 0; i < value.Length; i++)
        {
            var c = value[i];

            // If the character is a letter or digit, add it to the current word
            if (char.IsLetterOrDigit(c))
            {
                // If the current word has content and we encounter an uppercase letter following a lowercase letter, we consider it a new word (camelCase transition)
                if (current.Length > 0 && char.IsUpper(c) && char.IsLower(lastChar))
                {
                    words.Add(current.ToString());
                    current.Clear();
                }

                current.Append(c);
            }

            // If the character is not a letter or digit, we consider it a word boundary
            else if (current.Length > 0)
            {
                words.Add(current.ToString());
                current.Clear();
            }
            
            lastChar = c;
        }

        // Add the last word if there is any
        if (current.Length > 0)
        {
            words.Add(current.ToString());
        }

        return words.ToArray();
    }
}