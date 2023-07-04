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

    public Task RunAsync(CancellationToken cancellationToken = default)
    {
        var guidGen = _factory("system");
        _console.WriteLine();
        _console.WriteLine($"System GUIDs:");
        _console.WriteLine($"  {guidGen.NewGuid()}");
        _console.WriteLine($"  {guidGen.NewGuid()}");
        return Task.CompletedTask;
    }
}
