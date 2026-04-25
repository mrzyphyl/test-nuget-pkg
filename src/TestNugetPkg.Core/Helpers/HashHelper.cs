using System.Security.Cryptography;
using System.Text;

namespace TestNugetPkg.Core.Helpers;

#pragma warning disable CS1591

/// <summary>
/// Helper class for computing hashes.
/// </summary>
public static class HashHelper
{
    /// <summary>Computes MD5 hash of a string.</summary>
    public static string ComputeMd5(string input)
    {
        using var md5 = MD5.Create();
        var bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
        return Convert.ToHexString(bytes).ToLowerInvariant();
    }

    /// <summary>Computes SHA256 hash of a string.</summary>
    public static string ComputeSha256(string input)
    {
        using var sha256 = SHA256.Create();
        var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
        return Convert.ToHexString(bytes).ToLowerInvariant();
    }

    /// <summary>Computes SHA512 hash of a string.</summary>
    public static string ComputeSha512(string input)
    {
        using var sha512 = SHA512.Create();
        var bytes = sha512.ComputeHash(Encoding.UTF8.GetBytes(input));
        return Convert.ToHexString(bytes).ToLowerInvariant();
    }

    /// <summary>Generates a random hash.</summary>
    public static string GenerateRandomHash(int length = 32)
    {
        var bytes = new byte[length];
        RandomNumberGenerator.Fill(bytes);
        return Convert.ToHexString(bytes).ToLowerInvariant();
    }
}