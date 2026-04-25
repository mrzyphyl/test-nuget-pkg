namespace TestNugetPkg.Core.Utilities;

#pragma warning disable CS1591

/// <summary>
/// Provides reflection utility methods.
/// </summary>
public static class ReflectionUtility
{
    /// <summary>Gets all public properties of a type.</summary>
    public static IEnumerable<System.Reflection.PropertyInfo> GetProperties<T>() => typeof(T).GetProperties();

    /// <summary>Gets all public methods of a type.</summary>
    public static IEnumerable<System.Reflection.MethodInfo> GetMethods<T>() => typeof(T).GetMethods();

    /// <summary>Gets a property value by name.</summary>
    public static object? GetPropertyValue(object obj, string propertyName)
    {
        return obj.GetType().GetProperty(propertyName)?.GetValue(obj);
    }

    /// <summary>Sets a property value by name.</summary>
    public static void SetPropertyValue(object obj, string propertyName, object value)
    {
        obj.GetType().GetProperty(propertyName)?.SetValue(obj, value);
    }

    /// <summary>Creates an instance of a type using parameterless constructor.</summary>
    public static T CreateInstance<T>() where T : class => Activator.CreateInstance<T>()!;

    /// <summary>Creates an instance using constructor arguments.</summary>
    public static T CreateInstance<T>(params object[] args) where T : class
        => (T)Activator.CreateInstance(typeof(T), args)!;
}