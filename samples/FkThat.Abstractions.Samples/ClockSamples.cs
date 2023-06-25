namespace FkThat.Abstractions.Samples;

internal sealed class ClockSample : ISample
{
    private readonly IClock _clock;

    public ClockSample(IClock clock)
    {
        _clock = clock;
    }

    public async Task RunAsync(CancellationToken cancellationToken = default)
    {
        await Console.Out.WriteLineAsync($"UTC time: {_clock.UtcNow}.");
        await Console.Out.WriteLineAsync($"Local TZ: {_clock.LocalTimeZone}.");
        await Console.Out.WriteLineAsync($"Local time: {_clock.Now}.");
    }
}
