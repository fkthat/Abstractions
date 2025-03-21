namespace FkThat.Abstractions;

/// <summary>
/// Represents a clock.
/// </summary>
public interface IClock
{
    /// <summary>
    /// Gets a <c cref="DateTimeOffset"/> object whose date and time are set to the current
    /// Coordinated Universal Time (UTC) date and time and whose offset is <see cref="TimeSpan.Zero"/>.
    /// </summary>
    DateTimeOffset UtcNow { get; }
}
