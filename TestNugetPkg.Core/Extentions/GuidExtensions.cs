namespace TestNugetPkg.Core.Extentions;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

/// <summary>
/// Provides extension methods for working with Guid values.
/// </summary>
public static class GuidExtensions
{
    /// <summary>
    /// Returns true if the Guid is empty.
    /// </summary>
    /// <param name="guid">The Guid.</param>
    /// <returns>True if empty.</returns>
    public static bool IsEmpty(this Guid guid) => guid == Guid.Empty;

    /// <summary>
    /// Returns true if the Guid is not empty.
    /// </summary>
    /// <param name="guid">The Guid.</param>
    /// <returns>True if not empty.</returns>
    public static bool IsNotEmpty(this Guid guid) => guid != Guid.Empty;

    /// <summary>
    /// Converts a Guid to a short string representation (without dashes).
    /// </summary>
    /// <param name="guid">The Guid.</param>
    /// <returns>The short string.</returns>
    public static string ToShortString(this Guid guid) => guid.ToString("N");
}
