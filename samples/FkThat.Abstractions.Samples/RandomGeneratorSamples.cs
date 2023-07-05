namespace FkThat.Abstractions.Samples
{
    internal sealed class RandomGeneratorSamples : ISample
    {
        private readonly IConsole _console;
        private readonly Func<string, IRandomGenerator> _factory;

        public RandomGeneratorSamples(IConsole console, Func<string, IRandomGenerator> factory)
        {
            _console = console;
            _factory = factory;
        }

        public Task RunAsync(CancellationToken cancellationToken = default)
        {
            foreach (var generatorName in new[] { "crypto", "pseudo" })
            {
                var rand = _factory(generatorName);
                _console.WriteLine();
                _console.WriteLine($"Random ({generatorName}):");
                var randomInts = Enumerable.Repeat(0, 6).Select(_ => rand.GetInt32());
                var randomIntsStr = string.Join(", ", randomInts);
                _console.WriteLine(randomIntsStr);
            }

            return Task.CompletedTask;
        }
    }
}
