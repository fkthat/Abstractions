namespace FkThat.Abstractions;

/// <summary>
/// Represents the system clock.
/// </summary>
public sealed class SystemClock : IClock
{
    /// <inheritdoc/>
    public TimeZoneInfo LocalTimeZone => TimeZoneInfo.Local;

    /// <inheritdoc/>
    public DateTimeOffset GetUtcNow() => DateTimeOffset.UtcNow;
}
