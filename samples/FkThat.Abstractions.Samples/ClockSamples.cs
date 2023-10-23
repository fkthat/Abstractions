namespace FkThat.Abstractions.Samples;

internal sealed class ClockSample : ISample
{
    private readonly IClock _clock;
    private readonly ITimeZoneInfo _timeZoneInfo;

    public ClockSample(IClock clock, ITimeZoneInfo timeZoneInfo)
    {
        _clock = clock;
        _timeZoneInfo = timeZoneInfo;
    }

    public Task RunAsync(CancellationToken cancellationToken = default)
    {
        var utcNow = _clock.UtcNow;
        var tz = _timeZoneInfo.Local;
        Console.WriteLine($"UTC time: {utcNow}");
        Console.WriteLine($"Time zone: {tz}");
        Console.WriteLine($"Local time: {TimeZoneInfo.ConvertTime(utcNow, tz)}");
        return Task.CompletedTask;
    }
}
