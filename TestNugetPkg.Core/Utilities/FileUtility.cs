namespace TestNugetPkg.Core.Utilities;

#pragma warning disable CS1591

/// <summary>
/// Provides file system utility methods.
/// </summary>
public static class FileUtility
{
    /// <summary>Ensures a directory exists.</summary>
    public static void EnsureDirectoryExists(string path)
    {
        var dir = Path.GetDirectoryName(path);
        if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
    }
}