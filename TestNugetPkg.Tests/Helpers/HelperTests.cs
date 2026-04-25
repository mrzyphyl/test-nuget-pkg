using TestNugetPkg.Core.Helpers;

namespace TestNugetPkg.Tests.Helpers;

public class HashHelperTests
{
    [Fact]
    public void ComputeMd5() => Assert.Equal(32, HashHelper.ComputeMd5("hello").Length);

    [Fact]
    public void ComputeSha256() => Assert.Equal(64, HashHelper.ComputeSha256("hello").Length);

    [Fact]
    public void GenerateRandomHash() => Assert.Equal(32, HashHelper.GenerateRandomHash(16).Length);
}

public class EncodingHelperTests
{
    [Fact]
    public void ToBase64() => Assert.Equal("aGVsbG8=", EncodingHelper.ToBase64("hello"));

    [Fact]
    public void FromBase64() => Assert.Equal("hello", EncodingHelper.FromBase64("aGVsbG8="));

    [Fact]
    public void UrlEncode() => Assert.Contains("%20", EncodingHelper.UrlEncode("hello world"));

    [Fact]
    public void HtmlEncode() => Assert.Equal("&lt;test&gt;", EncodingHelper.HtmlEncode("<test>"));
}

public class RandomHelperTests
{
    [Fact]
    public void NextInt()
    {
        var result = RandomHelper.NextInt(1, 100);
        Assert.True(result >= 1 && result <= 100);
    }

    [Fact]
    public void NextString() => Assert.Equal(10, RandomHelper.NextString(10).Length);

    [Fact]
    public void NextBool() => Assert.Contains(RandomHelper.NextBool(), new[] { true, false });
}