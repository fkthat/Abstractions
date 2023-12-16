namespace FkThat.Abstractions.Clocks;

/// <inheritdoc/>
public class SystemTimeZoneInfo : ITimeZoneInfo
{
    /// <inheritdoc/>
    public TimeZoneInfo Local => TimeZoneInfo.Local;
}
