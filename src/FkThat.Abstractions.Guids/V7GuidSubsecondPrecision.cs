namespace FkThat.Abstractions;

/// <summary>
/// The precision of the subsecond part of the GUID v7.
/// </summary>
public enum V7GuidSubsecondPrecision
{
    /// <summary>
    /// The subseconnd part of the GUID v7 contains milliseconds.
    /// </summary>
    Millisescond = 0,

    /// <summary>
    /// The subseconnd part of the GUID v7 contains microseconds.
    /// </summary>
    Microsecond = 1,

    /// <summary>
    /// The subseconnd part of the GUID v7 contains nanoseconds.
    /// </summary>
    Nanosecond = 2
}
