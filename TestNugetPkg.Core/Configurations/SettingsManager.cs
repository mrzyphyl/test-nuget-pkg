namespace TestNugetPkg.Core.Configurations;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

/// <summary>
/// Helper class for managing application settings.
/// </summary>
public static class SettingsManager
{
    private static ConfigurationMetadata? _cachedConfig;
    private static string? _lastEnvironment;

    /// <summary>
    /// Gets the current application settings, caching by environment.
    /// </summary>
    /// <param name="basePath">Optional base path.</param>
    /// <param name="forceReload">Force reload from disk.</param>
    /// <returns>The application settings.</returns>
    public static ConfigurationMetadata GetSettings(string basePath = "", bool forceReload = false)
    {
        var currentEnv = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";

        if (!forceReload && _cachedConfig is not null && _lastEnvironment == currentEnv)
        {
            return _cachedConfig;
        }

        var config = ConfigurationLoader.LoadConfig<ConfigurationMetadata>(basePath, "settings");
        _cachedConfig = config ?? new ConfigurationMetadata { Environment = currentEnv };
        _lastEnvironment = currentEnv;

        return _cachedConfig;
    }

    /// <summary>
    /// Clears the cached settings.
    /// </summary>
    public static void ClearCache()
    {
        _cachedConfig = null;
        _lastEnvironment = null;
    }

    /// <summary>
    /// Gets a setting value by key.
    /// </summary>
    /// <param name="key">The setting key.</param>
    /// <param name="defaultValue">Default value if not found.</param>
    /// <returns>The setting value.</returns>
    public static string GetSetting(string key, string defaultValue = "")
    {
        var settings = GetSettings();
        return settings.Settings.TryGetValue(key, out var value) ? value : defaultValue;
    }

    /// <summary>
    /// Sets a setting value.
    /// </summary>
    /// <param name="key">The setting key.</param>
    /// <param name="value">The setting value.</param>
    public static void SetSetting(string key, string value)
    {
        var settings = GetSettings();
        settings.Settings[key] = value;
    }

    /// <summary>
    /// Checks if a setting exists.
    /// </summary>
    /// <param name="key">The setting key.</param>
    /// <returns>True if exists.</returns>
    public static bool HasSetting(string key)
    {
        return GetSettings().Settings.ContainsKey(key);
    }

    /// <summary>
    /// Gets all setting keys.
    /// </summary>
    /// <returns>Collection of setting keys.</returns>
    public static IEnumerable<string> GetSettingKeys()
    {
        return GetSettings().Settings.Keys;
    }
}