namespace TestNugetPkg.Core.Configurations;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

/// <summary>
/// Represents a configuration with metadata.
/// </summary>
public class ConfigurationMetadata
{
    /// <summary>The application name.</summary>
    public string AppName { get; set; } = string.Empty;

    /// <summary>The version.</summary>
    public string Version { get; set; } = "1.0.0";

    /// <summary>The environment name.</summary>
    public string Environment { get; set; } = "Production";

    /// <summary>Whether debug mode is enabled.</summary>
    public bool DebugMode { get; set; }

    /// <summary>The base URL.</summary>
    public string? BaseUrl { get; set; }

    /// <summary>The connection string.</summary>
    public string? ConnectionString { get; set; }

    /// <summary>Additional settings as key-value pairs.</summary>
    public Dictionary<string, string> Settings { get; set; } = new();
}