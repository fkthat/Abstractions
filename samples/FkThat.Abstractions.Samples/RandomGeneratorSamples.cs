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

        public async Task RunAsync(CancellationToken cancellationToken = default)
        {
            foreach (var s in new[] { "crypto", "pseudo" })
            {
                var rand = _factory("crypto");
                await _console.WriteLineAsync();
                await _console.WriteLineAsync($"Randoms ({s}):");
                var randomInts = Enumerable.Repeat(0, 6).Select(_ => rand.GetInt32());
                var randomIntsStr = string.Join(", ", randomInts);
                await _console.WriteLineAsync(randomIntsStr);
            }
        }
    }
}
