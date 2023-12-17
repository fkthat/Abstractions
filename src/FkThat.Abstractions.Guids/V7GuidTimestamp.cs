namespace FkThat.Abstractions.Guids;

internal readonly record struct V7GuidTimestamp(
    long UnixTimestamp,
    long Subseconds,
    V7GuidSubsecondPrecision Precision) : IComparable<V7GuidTimestamp>, IComparable
{
    public long Ticks => (UnixTimestamp * TimeSpan.TicksPerSecond) +
        Precision switch {
            V7GuidSubsecondPrecision.Millisescond => Subseconds * TimeSpan.TicksPerMillisecond,
            V7GuidSubsecondPrecision.Microsecond => Subseconds * TimeSpan.TicksPerMicrosecond,
            V7GuidSubsecondPrecision.Nanosecond => Subseconds / TimeSpan.NanosecondsPerTick,
            _ => throw new InvalidOperationException("Never be here.")
        };

    public int CompareTo(V7GuidTimestamp other) => Ticks.CompareTo(other.Ticks);

    public int CompareTo(object? obj) => obj switch {
        null => 1,
        V7GuidTimestamp other => CompareTo(other),
        _ => throw new ArgumentException($"Invalid {nameof(obj)} type", nameof(obj))
    };
}
