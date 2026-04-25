namespace TestNugetPkg.Core.Extensions;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

/// <summary>
/// Provides extension methods for working with DateTime and TimeSpan.
/// </summary>
public static class DateTimeExtensions
{
    /// <summary>
    /// Returns the start of the day (midnight).
    /// </summary>
    /// <param name="date">The date.</param>
    /// <returns>The start of the day.</returns>
    public static DateTime StartOfDay(this DateTime date) => date.Date;

    /// <summary>
    /// Returns the end of the day (11:59:59 PM).
    /// </summary>
    /// <param name="date">The date.</param>
    /// <returns>The end of the day.</returns>
    public static DateTime EndOfDay(this DateTime date) => date.Date.AddDays(1).AddTicks(-1);

    /// <summary>
    /// Returns the start of the week (Monday).
    /// </summary>
    /// <param name="date">The date.</param>
    /// <returns>The start of the week.</returns>
    public static DateTime StartOfWeek(this DateTime date)
    {
        var diff = (7 + (date.DayOfWeek - DayOfWeek.Monday)) % 7;
        return date.AddDays(-1 * diff).Date;
    }

    /// <summary>
    /// Returns the start of the month.
    /// </summary>
    /// <param name="date">The date.</param>
    /// <returns>The start of the month.</returns>
    public static DateTime StartOfMonth(this DateTime date) => new DateTime(date.Year, date.Month, 1);

    /// <summary>
    /// Returns the end of the month.
    /// </summary>
    /// <param name="date">The date.</param>
    /// <returns>The end of the month.</returns>
    public static DateTime EndOfMonth(this DateTime date) => new DateTime(date.Year, date.Month, 1).AddMonths(1).AddTicks(-1);

    /// <summary>
    /// Returns true if the date is today.
    /// </summary>
    /// <param name="date">The date.</param>
    /// <returns>True if today.</returns>
    public static bool IsToday(this DateTime date) => date.Date == DateTime.Today;

    /// <summary>
    /// Returns true if the date is in the past.
    /// </summary>
    /// <param name="date">The date.</param>
    /// <returns>True if in the past.</returns>
    public static bool IsPast(this DateTime date) => date < DateTime.Now;

    /// <summary>
    /// Returns true if the date is in the future.
    /// </summary>
    /// <param name="date">The date.</param>
    /// <returns>True if in the future.</returns>
    public static bool IsFuture(this DateTime date) => date > DateTime.Now;

    /// <summary>
    /// Returns a human-readable string describing the time difference.
    /// </summary>
    /// <param name="date">The date.</param>
    /// <returns>A human-readable string.</returns>
    public static string ToRelativeTime(this DateTime date)
    {
        var diff = DateTime.Now - date;

        if (diff.TotalSeconds < 60)
        {
            return "just now";
        }

        if (diff.TotalMinutes < 60)
        {
            return $"{(int)diff.TotalMinutes} minute(s) ago";
        }

        if (diff.TotalHours < 24)
        {
            return $"{(int)diff.TotalHours} hour(s) ago";
        }

        if (diff.TotalDays < 30)
        {
            return $"{(int)diff.TotalDays} day(s) ago";
        }

        if (diff.TotalDays < 365)
        {
            return $"{(int)(diff.TotalDays / 30)} month(s) ago";
        }

        return $"{(int)(diff.TotalDays / 365)} year(s) ago";
    }

    /// <summary>
    /// Checks if the year is a leap year.
    /// </summary>
    /// <param name="date">The date.</param>
    /// <returns>True if leap year.</returns>
    public static bool IsLeapYear(this DateTime date) => DateTime.IsLeapYear(date.Year);

    /// <summary>
    /// Returns the number of days in the month.
    /// </summary>
    /// <param name="date">The date.</param>
    /// <returns>Number of days.</returns>
    public static int DaysInMonth(this DateTime date) => DateTime.DaysInMonth(date.Year, date.Month);
}