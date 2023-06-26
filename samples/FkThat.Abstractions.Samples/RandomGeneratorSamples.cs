namespace FkThat.Abstractions.Samples
{
    internal sealed class RandomGeneratorSamples : ISample
    {
        private readonly Func<string, IRandomGenerator> _factory;

        public RandomGeneratorSamples(Func<string, IRandomGenerator> factory)
        {
            _factory = factory;
        }

        public async Task RunAsync(CancellationToken cancellationToken = default)
        {
            await Console.Out.WriteLineAsync();

            var rand = _factory("crypto");

            await Console.Out.WriteLineAsync(string.Format("Crypto randoms: {0}",
                string.Join(", ", Enumerable.Repeat(0, 6).Select(_ => rand.GetInt32()))));

            rand = _factory("pseudo");

            await Console.Out.WriteLineAsync(string.Format("Pseudo randoms: {0}",
                string.Join(", ", Enumerable.Repeat(0, 6).Select(_ => rand.GetInt32()))));
        }
    }
}
