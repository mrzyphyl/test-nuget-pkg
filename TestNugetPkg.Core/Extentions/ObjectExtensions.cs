using System.Text.Json;

namespace TestNugetPkg.Core.Extensions;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

/// <summary>
/// Provides extension methods for working with objects.
/// </summary>
public static class ObjectExtensions
{
    /// <summary>
    /// Converts an object to a JSON string.
    /// </summary>
    /// <param name="obj">The object to serialize.</param>
    /// <param name="pretty">Whether to format the JSON for readability.</param>
    /// <returns>The JSON string representation.</returns>
    public static string ToJson(this object? obj, bool pretty = false)
    {
        if (obj is null)
        {
            return "null";
        }

        var options = new JsonSerializerOptions
        {
            WriteIndented = pretty
        };

        return JsonSerializer.Serialize(obj, options);
    }

    /// <summary>
    /// Attempts to convert a JSON string to the specified type.
    /// </summary>
    /// <typeparam name="T">The target type.</typeparam>
    /// <param name="json">The JSON string.</param>
    /// <returns>The deserialized object, or default if failed.</returns>
    public static T? FromJson<T>(this string json)
    {
        if (string.IsNullOrWhiteSpace(json))
        {
            return default;
        }

        try
        {
            return JsonSerializer.Deserialize<T>(json);
        }
        catch
        {
            return default;
        }
    }

    /// <summary>
    /// Checks if an object is null or default value.
    /// </summary>
    /// <param name="obj">The object to check.</param>
    /// <returns>True if null or default.</returns>
    public static bool IsNullOrDefault(this object? obj)
    {
        if (obj is null)
        {
            return true;
        }

        return obj.Equals(default);
    }

    /// <summary>
    /// Creates a shallow copy of an object.
    /// </summary>
    /// <typeparam name="T">The object type.</typeparam>
    /// <param name="obj">The object to copy.</param>
    /// <returns>A shallow copy.</returns>
    public static T? Clone<T>(this T obj) where T : class
    {
        if (obj is null)
        {
            return null;
        }

        return obj.ToJson().FromJson<T>();
    }

    /// <summary>
    /// Converts an object to the specified type using conversion.
    /// </summary>
    /// <typeparam name="T">The target type.</typeparam>
    /// <param name="obj">The object to convert.</param>
    /// <returns>The converted object.</returns>
    public static T? As<T>(this object obj)
    {
        if (obj is null)
        {
            return default;
        }

        try
        {
            return (T)Convert.ChangeType(obj, typeof(T));
        }
        catch
        {
            return default;
        }
    }
}