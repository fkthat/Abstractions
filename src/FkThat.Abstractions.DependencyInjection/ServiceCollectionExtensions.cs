using Microsoft.Extensions.DependencyInjection;

namespace FkThat.Abstractions;

/// <summary>
/// Extension methods for <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds the CoreLib services.
    /// </summary>
    /// <param name="services">The service collection to add the services to.</param>
    /// <returns>The value of <paramref name="services"/>.</returns>
    public static IServiceCollection AddAbstractions(this IServiceCollection services) =>
        services.AddTransient<IClock, SystemClock>()
            .AddTransient<IGuidGenerator, V4GuidGenerator>()
            .AddKeyedTransient<IGuidGenerator, V4GuidGenerator>(GuidGeneratorServiceKey.V4)
            .AddKeyedTransient<IGuidGenerator, V7GuidGenerator>(GuidGeneratorServiceKey.V7)
            .AddTransient<IRandomGenerator, CryptoRandomGenerator>()
            .AddKeyedTransient<IRandomGenerator, CryptoRandomGenerator>(RandomGeneratorServiceKey.Crypto)
            .AddKeyedTransient<IRandomGenerator, PseudoRandomGenerator>(RandomGeneratorServiceKey.Pseudo)
            .AddTransient(typeof(IServiceProvider<>), typeof(ServiceProvider<>))
            .AddTransient<IConsoleKeyboard, SystemConsole>()
            .AddTransient<IConsoleText, SystemConsole>()
            .AddTransient<IConsoleBinary, SystemConsole>()
            .AddTransient<IEnvironment, SystemEnvironment>();
}
