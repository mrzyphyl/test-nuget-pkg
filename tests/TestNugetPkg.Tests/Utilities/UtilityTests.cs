using TestNugetPkg.Core.Utilities;

namespace TestNugetPkg.Tests.Utilities;

public class ValidationUtilityTests
{
    [Fact]
    public void ThrowIfNull() => Assert.Throws<ArgumentNullException>(() => ValidationUtility.ThrowIfNull(null!, "test"));

    [Fact]
    public void ThrowIfNullOrEmpty() => Assert.Throws<ArgumentException>(() => ValidationUtility.ThrowIfNullOrEmpty("", "test"));
}

public class FileUtilityTests
{
    private readonly string _tempFile;

    public FileUtilityTests()
    {
        _tempFile = Path.Combine(Path.GetTempPath(), $"Test_{Guid.NewGuid():N}.txt");
    }

    public void Dispose()
    {
        if (File.Exists(_tempFile))
            File.Delete(_tempFile);
    }
}