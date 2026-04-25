namespace TestNugetPkg.Core.Extensions;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

/// <summary>
/// Provides extension methods for working with collections.
/// </summary>
public static class CollectionExtensions
{
    /// <summary>
    /// Checks if a collection is null or empty.
    /// </summary>
    /// <typeparam name="T">The collection element type.</typeparam>
    /// <param name="collection">The collection to check.</param>
    /// <returns>True if null or empty.</returns>
    public static bool IsNullOrEmpty<T>(this IEnumerable<T>? collection)
    {
        return collection is null || !collection.Any();
    }

    /// <summary>
    /// Returns the first element or a default value if the collection is empty.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="collection">The collection.</param>
    /// <param name="defaultValue">The default value to return.</param>
    /// <returns>The first element or default.</returns>
    public static T? FirstOrDefault<T>(this IEnumerable<T> collection, T defaultValue)
    {
        if (collection is null)
        {
            return defaultValue;
        }

        var first = collection.FirstOrDefault();
        return first is null 
            ? defaultValue 
            : first;
    }

    /// <summary>
    /// Adds a range of items to a collection.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="collection">The collection to add to.</param>
    /// <param name="items">The items to add.</param>
    public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> items)
    {
        if (collection is null || items is null)
        {
            return;
        }

        foreach (var item in items)
        {
            collection.Add(item);
        }
    }

    /// <summary>
    /// Removes all items that match a condition.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="collection">The collection to modify.</param>
    /// <param name="predicate">The condition to match.</param>
    /// <returns>The number of items removed.</returns>
    public static int RemoveWhere<T>(this ICollection<T> collection, Func<T, bool> predicate)
    {
        if (collection is null || predicate is null)
        {
            return 0;
        }

        var itemsToRemove = collection.Where(predicate).ToList();
        foreach (var item in itemsToRemove)
        {
            collection.Remove(item);
        }

        return itemsToRemove.Count;
    }

    /// <summary>
    /// Returns a chunked version of the collection.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="collection">The collection.</param>
    /// <param name="size">The size of each chunk.</param>
    /// <returns>Collection of chunks.</returns>
    public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> collection, int size)
    {
        if (collection is null)
        {
            yield break;
        }

        var chunk = new List<T>();
        foreach (var item in collection)
        {
            chunk.Add(item);
            if (chunk.Count >= size)
            {
                yield return chunk;
                chunk = new List<T>();
            }
        }

        if (chunk.Count > 0)
        {
            yield return chunk;
        }
    }
}