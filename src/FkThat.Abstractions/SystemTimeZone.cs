namespace FkThat.Abstractions;

/// <inheritdoc/>
public sealed class SystemTimeZone : ITimeZone
{
    /// <inheritdoc/>
    public TimeZoneInfo Local => TimeZoneInfo.Local;
}
