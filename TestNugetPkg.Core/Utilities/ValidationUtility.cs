namespace TestNugetPkg.Core.Utilities;

#pragma warning disable CS1591

/// <summary>
/// Provides validation utility methods.
/// </summary>
public static class ValidationUtility
{
    /// <summary>Validates that an argument is not null.</summary>
    public static void ThrowIfNull(object? argument, string parameterName)
    {
        if (argument is null)
        {
            throw new ArgumentNullException(parameterName);
        }
    }

    /// <summary>Validates that a string is not null or empty.</summary>
    public static void ThrowIfNullOrEmpty(string? argument, string parameterName)
    {
        if (string.IsNullOrEmpty(argument))
        {
            throw new ArgumentException(parameterName);
        }
    }

    /// <summary>Validates that a condition is true.</summary>
    public static void ThrowIfFalse(bool condition, string message)
    {
        if (condition)
        {
            throw new InvalidOperationException(message);
        }
    }

    /// <summary>Validates that a condition is false.</summary>
    public static void ThrowIfTrue(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}