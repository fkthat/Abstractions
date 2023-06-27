namespace FkThat.Abstractions.Samples;

internal sealed class GuidGeneratorSamples : ISample
{
    private readonly IConsole _console;
    private readonly Func<string, IGuidGenerator> _factory;

    public GuidGeneratorSamples(IConsole console, Func<string, IGuidGenerator> factory)
    {
        _console = console;
        _factory = factory;
    }

    public async Task RunAsync(CancellationToken cancellationToken = default)
    {
        var guidGen = _factory("system");
        await _console.WriteLineAsync();
        await _console.WriteLineAsync($"Some system GUIDs:");
        await _console.WriteLineAsync(guidGen.NewGuid());
        await _console.WriteLineAsync(guidGen.NewGuid());
    }
}
