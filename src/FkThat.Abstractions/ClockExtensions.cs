namespace FkThat.Abstractions;

/// <summary>
/// <c cref="IClock"/> extension methods.
/// </summary>
public static class ClockExtensions
{
    /// <summary>
    /// Returns a <c cref="DateTimeOffset"/> object that is set to the current date and time on the
    /// current computer, with the offset set to the local time's offset from Coordinated Universal
    /// Time (UTC).
    /// </summary>
    public static DateTimeOffset GetLocalNow(this IClock clock)
    {
        _ = clock ?? throw new ArgumentNullException(nameof(clock));

        var utcNow = clock.GetUtcNow();
        var offset = clock.LocalTimeZone.GetUtcOffset(utcNow);

        return new DateTimeOffset(
            utcNow.Ticks + offset.Ticks,
            TimeSpan.FromTicks(offset.Ticks));
    }
}
