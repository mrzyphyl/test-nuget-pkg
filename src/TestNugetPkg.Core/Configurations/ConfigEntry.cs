namespace TestNugetPkg.Core.Configurations;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

/// <summary>
/// Represents a simple key-value configuration entry.
/// </summary>
public class ConfigEntry
{
    /// <summary>The configuration key.</summary>
    public string Key { get; set; } = string.Empty;

    /// <summary>The configuration value.</summary>
    public string Value { get; set; } = string.Empty;

    /// <summary>The environment name (optional).</summary>
    public string? Environment { get; set; }
}
