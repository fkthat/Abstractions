namespace FkThat.Abstractions;

/// <inheritdoc/>
public class SystemTimeZoneInfo : ITimeZoneInfo
{
    /// <inheritdoc/>
    public TimeZoneInfo Local => TimeZoneInfo.Local;
}
