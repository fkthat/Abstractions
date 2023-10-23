namespace FkThat.Abstractions.Samples
{
    internal sealed class RandomGeneratorSamples : ISample
    {
        private readonly Func<string, IRandomGenerator> _factory;

        public RandomGeneratorSamples(Func<string, IRandomGenerator> factory)
        {
            _factory = factory;
        }

        public Task RunAsync(CancellationToken cancellationToken = default)
        {
            foreach (var generatorName in new[] { "crypto", "pseudo" })
            {
                var rand = _factory(generatorName);
                Console.WriteLine();
                Console.WriteLine($"Random ({generatorName}):");
                var randomInts = Enumerable.Repeat(0, 6).Select(_ => rand.GetInt32());
                var randomIntsStr = string.Join(", ", randomInts);
                Console.WriteLine(randomIntsStr);
            }

            return Task.CompletedTask;
        }
    }
}
