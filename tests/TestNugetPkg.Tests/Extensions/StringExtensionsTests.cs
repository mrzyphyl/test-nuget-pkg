using TestNugetPkg.Core.Extensions;
using TestNugetPkg.Core.Extentions;

namespace TestNugetPkg.Tests.Extensions;

public class StringExtensionsTests
{
    [Fact]
    public void ToPascalCase_snake() => Assert.Equal("HelloWorld", "hello_world".ToPascalCase());

    [Fact]
    public void ToPascalCase_camel() => Assert.Equal("HelloWorld", "helloWorld".ToPascalCase());

    [Fact]
    public void ToPascalCase_upperSnake() => Assert.Equal("HelloWorld", "HELLO_WORLD".ToPascalCase());

    [Fact]
    public void ToPascalCase_kebab() => Assert.Equal("HelloWorld", "hello-world".ToPascalCase());

    [Fact]
    public void ToPascalCase_spaced() => Assert.Equal("HelloWorldTest", "hello world test".ToPascalCase());

    [Fact]
    public void ToPascalCase_alphanumeric() => Assert.Equal("Testing123", "Testing123".ToPascalCase());

    [Fact]
    public void ToPascalCase_empty() => Assert.Equal("", "".ToPascalCase());

    [Fact]
    public void ToPascalCase_uppercase() => Assert.Equal("Abc", "ABC".ToPascalCase());

    [Fact]
    public void ToCamelCase_snake() => Assert.Equal("helloWorld", "hello_world".ToCamelCase());

    [Fact]
    public void ToCamelCase_pascal() => Assert.Equal("helloWorld", "HelloWorld".ToCamelCase());

    [Fact]
    public void ToCamelCase_upperSnake() => Assert.Equal("helloWorld", "HELLO_WORLD".ToCamelCase());

    [Fact]
    public void ToSnakeCase_camel() => Assert.Equal("hello_world", "helloWorld".ToSnakeCase());

    [Fact]
    public void ToSnakeCase_pascal() => Assert.Equal("hello_world", "HelloWorld".ToSnakeCase());

    [Fact]
    public void ToSnakeCase_kebab() => Assert.Equal("hello_world", "hello-world".ToSnakeCase());

    [Theory]
    [InlineData("Testing123", "testing123")]
    public void ToSnakeCase_alphanumeric(string input, string expected) => Assert.Equal(expected, input.ToSnakeCase());

    [Fact]
    public void ToKebabCase_camel() => Assert.Equal("hello-world", "helloWorld".ToKebabCase());

    [Fact]
    public void ToKebabCase_pascal() => Assert.Equal("hello-world", "HelloWorld".ToKebabCase());

    [Theory]
    [InlineData("Testing123", "testing123")]
    public void ToKebabCase_alphanumeric(string input, string expected) => Assert.Equal(expected, input.ToKebabCase());

    [Fact]
    public void ToTrainCase_camel() => Assert.Equal("Hello-World", "helloWorld".ToTrainCase());

    [Theory]
    [InlineData("Testing123", "Testing123")]
    public void ToTrainCase_alphanumeric(string input, string expected) => Assert.Equal(expected, input.ToTrainCase());

    [Fact]
    public void ToConstantCase_camel() => Assert.Equal("HELLO_WORLD", "helloWorld".ToConstantCase());

    [Fact]
    public void ToConstantCase_snake() => Assert.Equal("HELLO_WORLD", "hello_world".ToConstantCase());

    [Fact]
    public void ToTitleCase() => Assert.Equal("Hello World", "hello world".ToTitleCase());
}

public class StringExtensions2Tests
{
    [Theory]
    [InlineData("", true)]
    [InlineData("   ", true)]
    [InlineData("hello", false)]
    public void IsBlank(string input, bool expected) => Assert.Equal(expected, input.IsBlank());

    [Theory]
    [InlineData("", false)]
    [InlineData("   ", false)]
    [InlineData("hello", true)]
    public void IsNotBlank(string input, bool expected) => Assert.Equal(expected, input.IsNotBlank());

    [Fact]
    public void OrDefault_null() => Assert.Equal("default", "".OrDefault("default"));

    [Fact]
    public void OrDefault_value() => Assert.Equal("value", "value".OrDefault("default"));

    [Fact]
    public void Reverse() => Assert.Equal("olleh", "hello".Reverse());

    [Fact]
    public void Left() => Assert.Equal("He", "Hello".Left(2));

    [Fact]
    public void Right() => Assert.Equal("lo", "Hello".Right(2));

    [Fact]
    public void Repeat() => Assert.Equal("hahaha", "ha".Repeat(3));
}

public class ObjectExtensionsTests
{
    [Fact]
    public void ToJson() => Assert.Contains("Test", new { Name = "Test" }.ToJson());

    [Fact]
    public void FromJson() => Assert.NotNull("{\"Name\":\"Test\"}".FromJson<object>());

    [Fact]
    public void Clone() => Assert.NotNull(new { Name = "Test" }.Clone<object>());

    [Theory]
    [InlineData(0, false)]
    [InlineData("", false)]
    [InlineData("value", false)]
    public void IsNullOrDefault(object input, bool expected) => Assert.Equal(expected, input.IsNullOrDefault());
}

public class CollectionExtensionsTests
{
    [Fact]
    public void IsNullOrEmpty() => Assert.True(new List<string>().IsNullOrEmpty());

    [Fact]
    public void IsNullOrEmpty_null() => Assert.True(((string[])null).IsNullOrEmpty());

    [Fact]
    public void AddRange()
    {
        var list = new List<string> { "a", "b", "c" };
        list.AddRange(new[] { "d", "e" });
        Assert.Equal(5, list.Count);
    }
}

public class DateTimeExtensionsTests
{
    [Fact]
    public void StartOfDay() => Assert.Equal(DateTime.Now.Date, DateTime.Now.StartOfDay());

    [Fact]
    public void IsToday() => Assert.True(DateTime.Today.IsToday());

    [Fact]
    public void IsPast() => Assert.True(DateTime.Now.AddDays(-1).IsPast());

    [Fact]
    public void IsFuture() => Assert.True(DateTime.Now.AddDays(1).IsFuture());

    [Fact]
    public void IsLeapYear() => Assert.True(new DateTime(2024, 1, 1).IsLeapYear());

    [Fact]
    public void DaysInMonth() => Assert.Equal(31, new DateTime(2026, 1, 1).DaysInMonth());
}

public class NumericExtensionsTests
{
    [Theory]
    [InlineData(50, 50, 1, 100)]
    [InlineData(0, 1, 1, 100)]
    [InlineData(150, 100, 1, 100)]
    public void Clamp(int value, int expected, int min, int max) => Assert.Equal(expected, value.Clamp(min, max));

    [Theory]
    [InlineData(50, true, 1, 100)]
    [InlineData(0, false, 1, 100)]
    public void IsBetween(int value, bool expected, int min, int max) => Assert.Equal(expected, value.IsBetween(min, max));

    [Theory]
    [InlineData(4, true)]
    [InlineData(5, false)]
    public void IsEven(int value, bool expected) => Assert.Equal(expected, value.IsEven());

    [Theory]
    [InlineData(5, true)]
    [InlineData(4, false)]
    public void IsOdd(int value, bool expected) => Assert.Equal(expected, value.IsOdd());

    [Fact]
    public void Abs() => Assert.Equal(5, (-5).Abs());
}

public class BooleanExtensionsTests
{
    [Theory]
    [InlineData(true, "Yes")]
    [InlineData(false, "No")]
    public void ToYesNo(bool input, string expected) => Assert.Equal(expected, input.ToYesNo());

    [Theory]
    [InlineData(true, "True")]
    [InlineData(false, "False")]
    public void ToTrueFalse(bool input, string expected) => Assert.Equal(expected, input.ToTrueFalse());
}

public class GuidExtensionsTests
{
    [Fact]
    public void IsEmpty() => Assert.True(Guid.Empty.IsEmpty());

    [Fact]
    public void IsNotEmpty() => Assert.True(Guid.NewGuid().IsNotEmpty());

    [Fact]
    public void ToShortString() => Assert.Equal(32, Guid.NewGuid().ToShortString().Length);
}