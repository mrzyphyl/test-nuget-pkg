namespace TestNugetPkg.Core.Extensions;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

/// <summary>
/// Provides extension methods for working with numbers.
/// </summary>
public static class NumericExtensions
{
    /// <summary>
    /// Clamps a value between a minimum and maximum.
    /// </summary>
    /// <typeparam name="T">The numeric type.</typeparam>
    /// <param name="value">The value to clamp.</param>
    /// <param name="min">Minimum value.</param>
    /// <param name="max">Maximum value.</param>
    /// <returns>The clamped value.</returns>
    public static T Clamp<T>(this T value, T min, T max) where T : IComparable<T>
    {
        // If value is less than min, return min. If value is greater than max, return max. Otherwise, return value.
        if (value.CompareTo(min) < 0)
        {
            return min;
        }

        // If value is greater than max, return max.
        if (value.CompareTo(max) > 0)
        {
            return max;
        }

        return value;
    }

    /// <summary>
    /// Checks if a value is between a minimum and maximum (inclusive).
    /// </summary>
    /// <typeparam name="T">The numeric type.</typeparam>
    /// <param name="value">The value to check.</param>
    /// <param name="min">Minimum value.</param>
    /// <param name="max">Maximum value.</param>
    /// <returns>True if within range.</returns>
    public static bool IsBetween<T>(this T value, T min, T max) where T : IComparable<T>
    {
        return value.CompareTo(min) >= 0 && value.CompareTo(max) <= 0;
    }

    /// <summary>
    /// Returns true if the number is even.
    /// </summary>
    /// <param name="value">The number.</param>
    /// <returns>True if even.</returns>
    public static bool IsEven(this int value) => value % 2 == 0;

    /// <summary>
    /// Returns true if the number is odd.
    /// </summary>
    /// <param name="value">The number.</param>
    /// <returns>True if odd.</returns>
    public static bool IsOdd(this int value) => value % 2 != 0;

    /// <summary>
    /// Rounds a number to the specified number of decimal places.
    /// </summary>
    /// <param name="value">The number.</param>
    /// <param name="decimals">Number of decimals.</param>
    /// <returns>The rounded number.</returns>
    public static decimal Round(this decimal value, int decimals = 2) => Math.Round(value, decimals);

    /// <summary>
    /// Rounds a number to the specified number of decimal places.
    /// </summary>
    /// <param name="value">The number.</param>
    /// <param name="decimals">Number of decimals.</param>
    /// <returns>The rounded number.</returns>
    public static double Round(this double value, int decimals = 2) => Math.Round(value, decimals);

    /// <summary>
    /// Returns the absolute value.
    /// </summary>
    /// <param name="value">The number.</param>
    /// <returns>The absolute value.</returns>
    public static decimal Abs(this decimal value) => Math.Abs(value);

    /// <summary>
    /// Returns the absolute value.
    /// </summary>
    /// <param name="value">The number.</param>
    /// <returns>The absolute value.</returns>
    public static double Abs(this double value) => Math.Abs(value);

    /// <summary>
    /// Returns the absolute value.
    /// </summary>
    /// <param name="value">The number.</param>
    /// <returns>The absolute value.</returns>
    public static int Abs(this int value) => Math.Abs(value);
}