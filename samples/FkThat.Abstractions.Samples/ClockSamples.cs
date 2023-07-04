namespace FkThat.Abstractions.Samples;

internal sealed class ClockSample : ISample
{
    private readonly IConsole _console;
    private readonly IClock _clock;
    private readonly ITimeZoneInfo _timeZoneInfo;

    public ClockSample(IConsole console, IClock clock, ITimeZoneInfo timeZoneInfo)
    {
        _console = console;
        _clock = clock;
        _timeZoneInfo = timeZoneInfo;
    }

    public async Task RunAsync(CancellationToken cancellationToken = default)
    {
        var utcNow = _clock.UtcNow;
        var tz = _timeZoneInfo.Local;
        await _console.WriteLineAsync($"UTC time: {utcNow}");
        await _console.WriteLineAsync($"Time zone: {tz}");
        await _console.WriteLineAsync($"Local time: {TimeZoneInfo.ConvertTime(utcNow, tz)}");
    }
}
