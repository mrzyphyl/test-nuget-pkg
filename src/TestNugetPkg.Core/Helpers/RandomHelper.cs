namespace TestNugetPkg.Core.Helpers;

#pragma warning disable CS1591

/// <summary>
/// Helper class for generating random values.
/// </summary>
public static class RandomHelper
{
    private static readonly Random _random = new();

    /// <summary>Generates a random integer between min and max.</summary>
    public static int NextInt(int min, int max) => _random.Next(min, max);

    /// <summary>Generates a random string of specified length.</summary>
    public static string NextString(int length, bool includeSpecial = false)
    {
        // Define character pools
        const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        const string special = "!@#$%^&*()_+-=[]{}|;:,.<>?";
        var pool = includeSpecial ? chars + special : chars;

        // Generate random string
        var result = new char[length];

        // Ensure at least one special character if required
        for (var i = 0; i < length; i++)
        {
            result[i] = pool[_random.Next(pool.Length)];
        }
        return new string(result);
    }

    /// <summary>Generates a random boolean.</summary>
    public static bool NextBool() => _random.Next(2) == 1;

    /// <summary>Generates a random double.</summary>
    public static double NextDouble(double min, double max) => min + (_random.NextDouble() * (max - min));
}