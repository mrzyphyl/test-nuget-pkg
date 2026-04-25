using TestNugetPkg.Core.Configurations;

namespace TestNugetPkg.Tests.Configurations;

public class ConfigurationLoaderTests
{
    private readonly string _testDir = Path.Combine(Path.GetTempPath(), $"TestNugetPkg_{Guid.NewGuid():N}");

    public ConfigurationLoaderTests()
    {
        Directory.CreateDirectory(_testDir);
        File.WriteAllText(Path.Combine(_testDir, "settings.json"), """{"AppName":"MyApp","Version":"1.0.0"}""");
        File.WriteAllText(Path.Combine(_testDir, "settings.development.json"), """{"AppName":"MyAppDev","DebugMode":true}""");
    }

    [Fact]
    public void LoadConfig_development()
    {
        Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development");
        var config = ConfigurationLoader.LoadConfigString(_testDir, "settings");
        Assert.NotNull(config);
        Assert.Contains("MyAppDev", config);
    }

    [Fact]
    public void LoadConfig_production()
    {
        Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Production");
        var config = ConfigurationLoader.LoadConfigString(_testDir, "settings");
        Assert.NotNull(config);
        Assert.Contains("MyApp", config);
    }
}