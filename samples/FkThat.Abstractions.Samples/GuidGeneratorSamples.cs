namespace FkThat.Abstractions.Samples;

internal sealed class GuidGeneratorSamples : ISample
{
    private readonly Func<string, IGuidGenerator> _factory;

    public GuidGeneratorSamples(Func<string, IGuidGenerator> factory)
    {
        _factory = factory;
    }

    public Task RunAsync(CancellationToken cancellationToken = default)
    {
        var guidGen = _factory("system");
        Console.WriteLine();
        Console.WriteLine($"System GUIDs:");
        Console.WriteLine($"  {guidGen.NewGuid()}");
        Console.WriteLine($"  {guidGen.NewGuid()}");
        return Task.CompletedTask;
    }
}
