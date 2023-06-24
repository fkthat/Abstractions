namespace FkThat.Abstractions;

/// <summary>
/// Represents the system clock.
/// </summary>
public class SystemClock : IClock
{
    /// <inheritdoc/>
    public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;

    /// <inheritdoc/>
    public TimeZoneInfo LocalTimeZone => TimeZoneInfo.Local;
}
