namespace TestNugetPkg.Core.Extentions;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

/// <summary>
/// Provides extension methods for working with boolean values.
/// </summary>
public static class BooleanExtensions
{
    /// <summary>
    /// Returns "Yes" if true, "No" otherwise.
    /// </summary>
    /// <param name="value">The boolean.</param>
    /// <returns>"Yes" or "No".</returns>
    public static string ToYesNo(this bool value) => value ? "Yes" : "No";

    /// <summary>
    /// Returns "True" if true, "False" otherwise.
    /// </summary>
    /// <param name="value">The boolean.</param>
    /// <returns>"True" or "False".</returns>
    public static string ToTrueFalse(this bool value) => value ? "True" : "False";

    /// <summary>
    /// Returns "1" if true, "0" otherwise.
    /// </summary>
    /// <param name="value">The boolean.</param>
    /// <returns>"1" or "0".</returns>
    public static string ToOneZero(this bool value) => value ? "1" : "0";
}