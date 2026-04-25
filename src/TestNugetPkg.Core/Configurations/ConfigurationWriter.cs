using System.Text.Json;

namespace TestNugetPkg.Core.Configurations;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

/// <summary>
/// Provides methods for creating configuration files.
/// </summary>
public static class ConfigurationWriter
{
    /// <summary>
    /// Saves configuration to a JSON file.
    /// </summary>
    /// <typeparam name="T">The configuration type.</typeparam>
    /// <param name="config">The configuration object.</param>
    /// <param name="filePath">The file path.</param>
    /// <param name="pretty">Whether to format the JSON.</param>
    public static void SaveConfig<T>(T config, string filePath, bool pretty = true) where T : class
    {
        if (config is null)
        {
            throw new ArgumentNullException(nameof(config));
        }

        var options = new JsonSerializerOptions
        {
            WriteIndented = pretty
        };

        var json = JsonSerializer.Serialize(config, options);
        File.WriteAllText(filePath, json);
    }

    /// <summary>
    /// Saves settings for a specific environment.
    /// </summary>
    /// <typeparam name="T">The configuration type.</typeparam>
    /// <param name="config">The configuration object.</param>
    /// <param name="basePath">The base path.</param>
    /// <param name="configFileName">The config file name.</param>
    /// <param name="environment">The environment name.</param>
    /// <param name="pretty">Whether to format the JSON.</param>
    public static void SaveEnvironmentConfig<T>(T config, string basePath, string configFileName, string environment, bool pretty = true) where T : class
    {
        var fileName = $"{configFileName}.{environment.ToLowerInvariant()}.json";
        var filePath = Path.Combine(basePath, fileName);
        SaveConfig(config, filePath, pretty);
    }

    /// <summary>
    /// Creates a default settings file.
    /// </summary>
    /// <param name="basePath">The base path.</param>
    /// <param name="appName">The application name.</param>
    public static void CreateDefaultSettings(string basePath, string appName = "MyApp")
    {
        var config = new ConfigurationMetadata
        {
            AppName = appName,
            Version = "1.0.0",
            Environment = "Development",
            DebugMode = true,
            Settings = new Dictionary<string, string>
            {
                { "Setting1", "Value1" },
                { "Setting2", "Value2" }
            }
        };

        SaveConfig(config, Path.Combine(basePath, "settings.json"));
    }

    /// <summary>
    /// Creates an environment-specific settings file.
    /// </summary>
    /// <param name="basePath">The base path.</param>
    /// <param name="environment">The environment name.</param>
    /// <param name="debugMode">Whether debug mode is enabled.</param>
    public static void CreateEnvironmentSettings(string basePath, string environment, bool debugMode = false)
    {
        var overrides = new Dictionary<string, object>
        {
            { "Environment", environment },
            { "DebugMode", debugMode }
        };

        var fileName = $"settings.{environment.ToLowerInvariant()}.json";
        var filePath = Path.Combine(basePath, fileName);

        var options = new JsonSerializerOptions { WriteIndented = true };
        File.WriteAllText(filePath, JsonSerializer.Serialize(overrides, options));
    }
}