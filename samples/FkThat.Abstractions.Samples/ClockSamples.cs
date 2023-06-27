namespace FkThat.Abstractions.Samples;

internal sealed class ClockSample : ISample
{
    private readonly IConsole _console;
    private readonly IClock _clock;

    public ClockSample(IConsole console, IClock clock)
    {
        _console = console;
        _clock = clock;
    }

    public async Task RunAsync(CancellationToken cancellationToken = default)
    {
        await _console.WriteLineAsync(_clock.GetUtcNow());
        await _console.WriteLineAsync(_clock.LocalTimeZone);
        await _console.WriteLineAsync(_clock.GetLocalNow());
    }
}
