﻿namespace FkThat.Abstractions.Clocks;

/// <summary>
/// Provides access to the local <see cref="TimeZoneInfo"/>.
/// </summary>
public interface ITimeZoneInfo
{
    /// <summary>
    /// Gets a <see cref="TimeZoneInfo"/> object that represents the local time zone.
    /// </summary>
    TimeZoneInfo Local { get; }
}
