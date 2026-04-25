namespace TestNugetPkg.Core.Utilities;

#pragma warning disable CS1591

/// <summary>
/// Provides async utility methods.
/// </summary>
public static class AsyncUtility
{
    /// <summary>Runs a function synchronously.</summary>
    public static T RunSync<T>(Func<Task<T>> func) => func().GetAwaiter().GetResult();

    /// <summary>Runs an action synchronously.</summary>
    public static void RunSync(Func<Task> func) => func().GetAwaiter().GetResult();

    /// <summary>Wraps a value in a completed task.</summary>
    public static Task<T> FromResult<T>(T result) => Task.FromResult(result);
}