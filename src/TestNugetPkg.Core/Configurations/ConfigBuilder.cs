using Microsoft.Extensions.Configuration;

namespace TestNugetPkg.Core.Configurations;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

/// <summary>
/// Provides methods for building IConfigurationRoot with JSON configuration files.
/// </summary>
public static class ConfigBuilder
{
    /// <summary>
    /// Builds an IConfigurationRoot with settings.json and environment-specific settings.
    /// </summary>
    /// <param name="configure">Optional action to configure additional providers.</param>
    /// <returns>The built configuration root.</returns>
    public static IConfigurationRoot BuildConfiguration(Action<IConfigurationBuilder>? configure = null)
    {
        var builder = new ConfigurationBuilder();
        builder.SetBasePath(AppContext.BaseDirectory);
        builder.AddJsonFile("settings.json", optional: true, reloadOnChange: false);

        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";
        builder.AddJsonFile($"settings.{environment}.json", optional: true, reloadOnChange: false);

        configure?.Invoke(builder);

        return builder.Build();
    }

    /// <summary>
    /// Builds an IConfigurationRoot with a custom base path.
    /// </summary>
    /// <param name="basePath">The base directory for configuration files.</param>
    /// <param name="configure">Optional action to configure additional providers.</param>
    /// <returns>The built configuration root.</returns>
    public static IConfigurationRoot BuildConfiguration(string basePath, Action<IConfigurationBuilder>? configure = null)
    {
        var builder = new ConfigurationBuilder();
        builder.SetBasePath(basePath);
        builder.AddJsonFile("settings.json", optional: true, reloadOnChange: false);

        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";
        builder.AddJsonFile($"settings.{environment}.json", optional: true, reloadOnChange: false);

        configure?.Invoke(builder);

        return builder.Build();
    }
}