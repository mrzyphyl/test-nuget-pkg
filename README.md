# TestNugetPkg.Core

A comprehensive .NET library providing helper extensions, configurations, utilities, and helpers for ASP.NET applications.

## Installation

```bash
dotnet add package TestNugetPkg.Core
```

Or reference directly in your project:

```xml
<ProjectReference Include="..\TestNugetPkg.Core\TestNugetPkg.Core.csproj" />
```

## Solution Structure

```
test-nuget-package/
├── TestNugetPkg.sln           # Visual Studio solution
├── README.md
├── src/
│   └── TestNugetPkg.Core/     # Class Library
│       ├── Extensions/
│       ├── Configurations/
│       ├── Helpers/
│       └── Utilities/
└── tests/
    └── TestNugetPkg.Tests/    # xUnit test project
        ├── Extensions/
        ├── Configurations/
        ├── Helpers/
        └── Utilities/
```

## Building

```bash
# Build entire solution
dotnet build TestNugetPkg.sln

# Run tests
dotnet test tests/TestNugetPkg.Tests/TestNugetPkg.Tests.csproj
```

---

## Extensions

### StringExtensions

String case conversion extension methods.

```csharp
using TestNugetPkg.Core.Extensions;

string pascal = "hello_world".ToPascalCase();     // "HelloWorld"
string camel = "HelloWorld".ToCamelCase();    // "helloWorld"
string snake = "HelloWorld".ToSnakeCase();    // "hello_world"
string kebab = "HelloWorld".ToKebabCase();     // "hello-world"
string train = "helloWorld".ToTrainCase();     // "Hello-World"
string constant = "helloWorld".ToConstantCase(); // "HELLO_WORLD"
string title = "hello world".ToTitleCase();   // "Hello World"
```

**Methods:**
- `ToPascalCase(string)` - Converts to PascalCase
- `ToCamelCase(string)` - Converts to camelCase
- `ToSnakeCase(string)` - Converts to snake_case
- `ToKebabCase(string)` - Converts to kebab-case
- `ToTrainCase(string)` - Converts to Train-Case
- `ToConstantCase(string)` - Converts to CONSTANT_CASE
- `ToTitleCase(string)` - Converts to Title Case

### StringExtensions2

Additional string utility methods.

```csharp
using TestNugetPkg.Core.Extensions;

bool isBlank = "".IsBlank();              // true
bool isNotBlank = "hello".IsNotBlank();    // true
string truncated = "Hello World".Truncate(8); // "Hello..."
string reversed = "hello".Reverse();       // "olleh"
string left = "Hello".Left(2);          // "He"
string right = "Hello".Right(2);         // "lo"
string normalized = "hello   world".NormalizeWhitespace(); // "hello world"
string repeated = "ha".Repeat(3);      // "hahaha"
```

**Methods:**
- `IsBlank(string)` - Checks if null, empty, or whitespace
- `IsNotBlank(string)` - Checks if has content
- `OrDefault(string, string)` - Returns default if null/empty
- `Truncate(string, int, string)` - Truncates with suffix
- `Reverse(string)` - Reverses the string
- `Left(string, int)` - Gets leftmost characters
- `Right(string, int)` - Gets rightmost characters
- `NormalizeWhitespace(string)` - Normalizes whitespace
- `Repeat(string, int)` - Repeats the string
- `PadLeft(string, int, char)` - Pads left
- `PadRight(string, int, char)` - Pads right

### ObjectExtensions

Object manipulation extensions.

```csharp
using TestNugetPkg.Core.Extensions;

string json = myObject.ToJson(pretty: true);
var obj = json.FromJson<MyClass>();
var clone = myObject.Clone<MyClass>();
bool isDefault = obj.IsNullOrDefault();
```

**Methods:**
- `ToJson(object, bool)` - Serializes to JSON
- `FromJson<T>(string)` - Deserializes from JSON
- `IsNullOrDefault(object)` - Checks if null/default
- `Clone<T>(object)` - Creates a shallow copy
- `As<T>(object)` - Converts to type

### CollectionExtensions

Collection manipulation extensions.

```csharp
using TestNugetPkg.Core.Extensions;

bool isEmpty = list.IsNullOrEmpty();
list.AddRange(otherItems);
var chunks = collection.Chunk(3);
```

**Methods:**
- `IsNullOrEmpty<T>(IEnumerable<T>)` - Checks if null/empty
- `FirstOrDefault<T>(IEnumerable<T>, T)` - Returns first or default
- `AddRange<T>(ICollection<T>, IEnumerable<T>)` - Adds multiple items
- `RemoveWhere<T>(ICollection<T>, Func<T, bool>)` - Removes matching items
- `Chunk<T>(IEnumerable<T>, int)` - Splits into chunks

### DateTimeExtensions

DateTime manipulation extensions.

```csharp
using TestNugetPkg.Core.Extensions;

DateTime startOfDay = date.StartOfDay();
DateTime endOfDay = date.EndOfDay();
DateTime startOfWeek = date.StartOfWeek();
DateTime startOfMonth = date.StartOfMonth();
DateTime endOfMonth = date.EndOfMonth();
bool isToday = date.IsToday();
bool isPast = date.IsPast();
bool isFuture = date.IsFuture();
string relative = date.ToRelativeTime(); // "2 hours ago"
bool isLeap = date.IsLeapYear();
int days = date.DaysInMonth();
```

**Methods:**
- `StartOfDay(DateTime)` - Returns midnight
- `EndOfDay(DateTime)` - Returns 11:59:59 PM
- `StartOfWeek(DateTime)` - Returns Monday of week
- `StartOfMonth(DateTime)` - Returns first of month
- `EndOfMonth(DateTime)` - Returns last of month
- `IsToday(DateTime)` - Checks if today
- `IsPast(DateTime)` - Checks if in past
- `IsFuture(DateTime)` - Checks if in future
- `ToRelativeTime(DateTime)` - Returns human-readable time
- `IsLeapYear(DateTime)` - Checks leap year
- `DaysInMonth(DateTime)` - Returns days in month

### NumericExtensions

Numeric manipulation extensions.

```csharp
using TestNugetPkg.Core.Extensions;

int clamped = value.Clamp(1, 100);
bool inRange = value.IsBetween(1, 100);
bool isEven = value.IsEven();
bool isOdd = value.IsOdd();
decimal rounded = value.Round(2);
int abs = value.Abs();
```

**Methods:**
- `Clamp<T>(T, T, T)` - Clamps value between min/max
- `IsBetween<T>(T, T, T)` - Checks if within range
- `IsEven(int)` - Checks if even
- `IsOdd(int)` - Checks if odd
- `Round(decimal/int, int)` - Rounds to decimals
- `Abs(decimal/int/double)` - Returns absolute value

---

## Configurations

### ConfigurationLoader

Load configuration files with environment-specific overrides.

```csharp
using TestNugetPkg.Core.Configurations;

// Auto-detects environment from ASPNETCORE_ENVIRONMENT
var config = ConfigurationLoader.LoadConfig<ConfigurationMetadata>();

// Or specify environment explicitly
var config = ConfigurationLoader.LoadConfig<ConfigurationMetadata>("C:\\app\\config", "settings", "Development");

// Load raw JSON string
var json = ConfigurationLoader.LoadConfigString(basePath, "settings");
```

**File Resolution:**
- First looks for `settings.{environment}.json` (e.g., `settings.development.json`)
- Falls back to `settings.json` if not found
- Returns null if neither exists

### SettingsManager

Caches and manages application settings.

```csharp
using TestNugetPkg.Core.Configurations;

var settings = SettingsManager.GetSettings();
string value = SettingsManager.GetSetting("MyKey", "default");
SettingsManager.SetSetting("MyKey", "newValue");
bool hasKey = SettingsManager.HasSetting("MyKey");
SettingsManager.ClearCache(); // Force reload
```

### ConfigurationWriter

Creates and saves configuration files.

```csharp
using TestNugetPkg.Core.Configurations;

ConfigurationWriter.SaveConfig(myConfig, "C:\\app\\settings.json");
ConfigurationWriter.CreateDefaultSettings("C:\\app", "MyApp");
```

---

## Helpers

### HashHelper

Compute cryptographic hashes.

```csharp
using TestNugetPkg.Core.Helpers;

string md5 = HashHelper.ComputeMd5("input");
string sha256 = HashHelper.ComputeSha256("input");
string sha512 = HashHelper.ComputeSha512("input");
string random = HashHelper.GenerateRandomHash(32);
```

### EncodingHelper

Encode and decode strings.

```csharp
using TestNugetPkg.Core.Helpers;

string base64 = EncodingHelper.ToBase64("hello");
string decoded = EncodingHelper.FromBase64("aGVsbG8=");
string url = EncodingHelper.UrlEncode("hello world");
string html = EncodingHelper.HtmlEncode("<script>");
```

### RandomHelper

Generate random values.

```csharp
using TestNugetPkg.Core.Helpers;

int number = RandomHelper.NextInt(1, 100);
string text = RandomHelper.NextString(16, includeSpecial: true);
bool flag = RandomHelper.NextBool();
double value = RandomHelper.NextDouble(0.0, 1.0);
```

---

## Utilities

### ValidationUtility

Throw exceptions for validation.

```csharp
using TestNugetPkg.Core.Utilities;

ValidationUtility.ThrowIfNull(arg, nameof(arg));
ValidationUtility.ThrowIfNullOrEmpty(arg, nameof(arg));
ValidationUtility.ThrowIfFalse(condition, "Invalid state");
```

### ReflectionUtility

Work with types via reflection.

```csharp
using TestNugetPkg.Core.Utilities;

var props = ReflectionUtility.GetProperties<MyClass>();
var instance = ReflectionUtility.CreateInstance<MyClass>();
var value = ReflectionUtility.GetPropertyValue(obj, "Name");
```

### FileUtility

File system operations.

```csharp
using TestNugetPkg.Core.Utilities;

FileUtility.EnsureDirectoryExists(path);
string[] lines = FileUtility.ReadAllLines(path);
long size = FileUtility.GetFileSize(path);
```

### AsyncUtility

Async utilities.

```csharp
using TestNugetPkg.Core.Utilities;

var result = AsyncUtility.RunSync(() => GetDataAsync());
```

---

## Testing

The project includes **xUnit** tests (79+ test cases).

```bash
# Run all tests
dotnet test tests/TestNugetPkg.Tests/TestNugetPkg.Tests.csproj
```

**Test Categories:**
- **Extensions:** StringExtensions, ObjectExtensions, CollectionExtensions, DateTimeExtensions, NumericExtensions, BooleanExtensions, GuidExtensions
- **Configurations:** ConfigurationLoader tests
- **Helpers:** HashHelper, EncodingHelper, RandomHelper
- **Utilities:** ValidationUtility, FileUtility

---

## Configuration File Examples

### settings.json

```json
{
  "appName": "MyApp",
  "version": "1.0.0",
  "environment": "Development",
  "debugMode": true,
  "settings": {
    "Setting1": "Value1"
  }
}
```

### settings.development.json

```json
{
  "appName": "MyApp",
  "environment": "Development",
  "debugMode": true
}
```

---

## License

MIT License - See LICENSE file for details.