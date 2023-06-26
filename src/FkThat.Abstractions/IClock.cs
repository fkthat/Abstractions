namespace FkThat.Abstractions;

/// <summary>
/// Represents a clock.
/// </summary>
public interface IClock
{
    /// <summary>
    /// Gets a <c cref="TimeZoneInfo"/> object that represents the local time zone.
    /// </summary>
    /// <returns>An object that represents the local time zone.</returns>
    TimeZoneInfo LocalTimeZone { get; }

    /// <summary>
    /// Returns a <c cref="DateTimeOffset"/> object whose date and time are set to the current
    /// Coordinated Universal Time (UTC) date and time and whose offset is <c c="TimeSpan.Zero"/>.
    /// </summary>
    DateTimeOffset GetUtcNow();
}
