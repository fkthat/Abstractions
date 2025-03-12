using Microsoft.Extensions.DependencyInjection;

namespace FkThat.Abstractions;

public class ServiceCollectionExtensionsTests
{
    [Theory]
    [InlineData(typeof(IClock))]
    [InlineData(typeof(IGuidGenerator))]
    [InlineData(typeof(IRandomGenerator))]
    [InlineData(typeof(IServiceProvider<>))]
    [InlineData(typeof(IEnvironment))]
    [InlineData(typeof(IConsoleText))]
    [InlineData(typeof(IConsoleBinary))]
    [InlineData(typeof(IConsoleKeyboard))]
    public void AddAbstractions_registers_services(Type type)
    {
        ServiceCollection sut = new();
        sut.AddAbstractions();
        sut.Should().Contain(x => x.ServiceType == type);
    }

    [Fact]
    public void AddAbstractions_registers_keyed_GuidGenerators()
    {
        ServiceCollection sut = new();
        sut.AddAbstractions();

        using var sp = sut.BuildServiceProvider();

        sp.GetKeyedService<IGuidGenerator>(GuidGeneratorServiceKey.V4)
            .Should().BeOfType<V4GuidGenerator>();

        sp.GetKeyedService<IGuidGenerator>(GuidGeneratorServiceKey.V7)
            .Should().BeOfType<V7GuidGenerator>();
    }

    [Fact]
    public void AddAbstractions_registers_keyed_RandomGenerators()
    {
        ServiceCollection sut = new();
        sut.AddAbstractions();

        using var sp = sut.BuildServiceProvider();

        sp.GetKeyedService<IRandomGenerator>(RandomGeneratorServiceKey.Crypto)
            .Should().BeOfType<CryptoRandomGenerator>();

        sp.GetKeyedService<IRandomGenerator>(RandomGeneratorServiceKey.Pseudo)
            .Should().BeOfType<PseudoRandomGenerator>();
    }
}
