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

    public Task RunAsync(CancellationToken cancellationToken = default)
    {
        var utcNow = _clock.UtcNow;
        var tz = _timeZoneInfo.Local;
        _console.WriteLine($"UTC time: {utcNow}");
        _console.WriteLine($"Time zone: {tz}");
        _console.WriteLine($"Local time: {TimeZoneInfo.ConvertTime(utcNow, tz)}");
        return Task.CompletedTask;
    }
}
