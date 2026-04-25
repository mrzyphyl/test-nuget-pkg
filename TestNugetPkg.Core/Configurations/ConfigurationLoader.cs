using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace TestNugetPkg.Core.Configurations;


#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

/// <summary>
/// Provides methods for loading configuration files based on environment.
/// </summary>
/// <remarks>
/// This class loads JSON configuration files with environment-specific overrides.
/// It looks for settings.environment.json files (e.g., settings.development.json, settings.Production.json)
/// based on the ASPNETCORE_ENVIRONMENT environment variable.
/// </remarks>
public static class ConfigurationLoader
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    /// <summary>
    /// Loads a configuration object from a JSON file, automatically detecting environment.
    /// </summary>
    /// <typeparam name="T">The type to deserialize the configuration to.</typeparam>
    /// <param name="basePath">The base directory to search for config files. Defaults to AppContext.BaseDirectory.</param>
    /// <param name="configFileName">The base name of the config file (e.g., "settings"). Defaults to "settings".</param>
    /// <returns>The deserialized configuration object, or null if not found.</returns>
    /// <example>
    /// <code>
    /// var config = ConfigurationLoader.LoadConfig&lt;AppConfig&gt;("C:\\app", "settings");
    /// </code>
    /// </example>
    public static T? LoadConfig<T>(string basePath = "", string configFileName = "settings") where T : class, new()
    {
        var environment = GetEnvironment();
        var configPath = ResolveConfigPath(basePath, configFileName, environment);
        return LoadConfigFromPath<T>(configPath);
    }

    /// <summary>
    /// Loads a configuration object from a JSON file with a specific environment.
    /// </summary>
    /// <typeparam name="T">The type to deserialize the configuration to.</typeparam>
    /// <param name="basePath">The base directory to search for config files.</param>
    /// <param name="configFileName">The base name of the config file.</param>
    /// <param name="environment">The environment name (e.g., "Development", "Production").</param>
    /// <returns>The deserialized configuration object, or null if not found.</returns>
    public static T? LoadConfig<T>(string basePath, string configFileName, string? environment) where T : class, new()
    {
        var configPath = ResolveConfigPath(basePath, configFileName, environment);
        return LoadConfigFromPath<T>(configPath);
    }

    /// <summary>
    /// Loads a configuration object with an explicit environment override.
    /// </summary>
    /// <typeparam name="T">The type to deserialize the configuration to.</typeparam>
    /// <param name="basePath">The base directory to search for config files.</param>
    /// <param name="configFileName">The base name of the config file.</param>
    /// <param name="explicitEnvironment">Explicit environment to use (overrides ASPNETCORE_ENVIRONMENT).</param>
    /// <returns>The deserialized configuration object, or null if not found.</returns>
    public static T? LoadEnvironmentConfig<T>(string basePath = "", string configFileName = "settings", string? explicitEnvironment = null) where T : class, new()
    {
        var environment = explicitEnvironment ?? GetEnvironment();
        var configPath = ResolveConfigPath(basePath, configFileName, environment);
        return LoadConfigFromPath<T>(configPath);
    }

    /// <summary>
    /// Loads a configuration file as a raw JSON string, automatically detecting environment.
    /// </summary>
    /// <param name="basePath">The base directory to search for config files.</param>
    /// <param name="configFileName">The base name of the config file.</param>
    /// <returns>The JSON content as a string, or null if not found.</returns>
    public static string? LoadConfigString(string basePath = "", string configFileName = "settings")
    {
        var environment = GetEnvironment();
        var configPath = ResolveConfigPath(basePath, configFileName, environment);
        return File.Exists(configPath) ? File.ReadAllText(configPath) : null;
    }

    /// <summary>
    /// Loads a configuration file as a raw JSON string with a specific environment.
    /// </summary>
    /// <param name="basePath">The base directory to search for config files.</param>
    /// <param name="configFileName">The base name of the config file.</param>
    /// <param name="environment">The environment name.</param>
    /// <returns>The JSON content as a string, or null if not found.</returns>
    public static string? LoadConfigString(string basePath, string configFileName, string? environment)
    {
        var configPath = ResolveConfigPath(basePath, configFileName, environment);
        return File.Exists(configPath) ? File.ReadAllText(configPath) : null;
    }

    /// <summary>
    /// Loads a configuration file as a JsonElement, automatically detecting environment.
    /// </summary>
    /// <param name="basePath">The base directory to search for config files.</param>
    /// <param name="configFileName">The base name of the config file.</param>
    /// <returns>The JsonElement, or null if not found.</returns>
    public static JsonElement? LoadConfigJson(string basePath = "", string configFileName = "settings")
    {
        var json = LoadConfigString(basePath, configFileName);
        if (string.IsNullOrWhiteSpace(json))
        {
            return default;
        }

        return JsonSerializer.Deserialize<JsonElement>(json);
    }

    /// <summary>
    /// Loads a configuration file as a JsonElement with a specific environment.
    /// </summary>
    /// <param name="basePath">The base directory to search for config files.</param>
    /// <param name="configFileName">The base name of the config file.</param>
    /// <param name="environment">The environment name.</param>
    /// <returns>The JsonElement, or null if not found.</returns>
    public static JsonElement? LoadConfigJson(string basePath, string configFileName, string? environment)
    {
        var json = LoadConfigString(basePath, configFileName, environment);
        if (string.IsNullOrWhiteSpace(json))
        {
            return default;
        }

        return JsonSerializer.Deserialize<JsonElement>(json);
    }

    private static string GetEnvironment()
    {
        var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        return env ?? "Production";
    }

    private static string ResolveConfigPath(string basePath, string configFileName, string? environment)
    {
        if (string.IsNullOrWhiteSpace(basePath))
        {
            basePath = AppContext.BaseDirectory;
        }

        if (!basePath.EndsWith(Path.DirectorySeparatorChar) && !basePath.EndsWith(Path.AltDirectorySeparatorChar))
        {
            basePath += Path.DirectorySeparatorChar;
        }

        // Normalize environment name for file naming
        var envFileName = $"{configFileName}.{NormalizeEnvironment(environment)}.json";
        var defaultFileName = $"{configFileName}.json";

        var envPath = Path.Combine(basePath, envFileName);
        if (File.Exists(envPath))
        {
            return envPath;
        }

        var defaultPath = Path.Combine(basePath, defaultFileName);
        if (File.Exists(defaultPath))
        {
            return defaultPath;
        }

        return envPath;
    }

    private static string NormalizeEnvironment(string? environment)
    {
        if (string.IsNullOrWhiteSpace(environment))
        {
            return "Production";
        }

        var normalized = environment.Trim();
        if (normalized.Equals("Development", StringComparison.OrdinalIgnoreCase))
        {
            return "development";
        }

        if (normalized.Equals("Production", StringComparison.OrdinalIgnoreCase))
        {
            return "Production";
        }

        return normalized.ToLowerInvariant();
    }

    private static T? LoadConfigFromPath<T>(string path) where T : class, new()
    {
        if (!File.Exists(path))
        {
            return default;
        }

        var json = File.ReadAllText(path);
        if (string.IsNullOrWhiteSpace(json))
        {
            return default;
        }

        return JsonSerializer.Deserialize<T>(json, JsonOptions);
    }
}