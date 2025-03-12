using Microsoft.Extensions.DependencyInjection;

namespace FkThat.Abstractions;

file interface IFoo { }

public class ServiceProviderTests
{
    [Fact]
    public void GetService_returns_default_service()
    {
        var serviceProvider = A.Fake<IServiceProvider>();
        var foo = A.Fake<IFoo>();
        A.CallTo(() => serviceProvider.GetService(typeof(IFoo))).Returns(foo);

        ServiceProvider<IFoo> sut = new(serviceProvider);
        var actual = sut.GetService();

        actual.Should().Be(foo);
    }

    [Fact]
    public void GetService_returns_keyed_service()
    {
        var serviceProvider = A.Fake<IKeyedServiceProvider>();
        var foo = A.Fake<IFoo>();
        var key = new object();
        A.CallTo(() => serviceProvider.GetKeyedService(typeof(IFoo), key)).Returns(foo);

        ServiceProvider<IFoo> sut = new(serviceProvider);
        var actual = sut.GetService(key);

        actual.Should().Be(foo);
    }

    [Fact]
    public void GetRequiredService_returns_default_service()
    {
        var serviceProvider = A.Fake<IServiceProvider>();
        var foo = A.Fake<IFoo>();
        A.CallTo(() => serviceProvider.GetService(typeof(IFoo))).Returns(foo);

        ServiceProvider<IFoo> sut = new(serviceProvider);
        var actual = sut.GetRequiredService();

        actual.Should().Be(foo);
    }

    [Fact]
    public void GetRequiredService_returns_keyed_service()
    {
        var serviceProvider = A.Fake<IKeyedServiceProvider>();
        var foo = A.Fake<IFoo>();
        var key = new object();
        A.CallTo(() => serviceProvider.GetRequiredKeyedService(typeof(IFoo), key)).Returns(foo);

        ServiceProvider<IFoo> sut = new(serviceProvider);
        var actual = sut.GetRequiredService(key);

        actual.Should().Be(foo);
    }

    [Fact]
    public void GetRequiredService_unregistered_default_service_throws()
    {
        var serviceProvider = A.Fake<IKeyedServiceProvider>();
        A.CallTo(() => serviceProvider.GetService(typeof(IFoo))).Returns(null);

        ServiceProvider<IFoo> sut = new(serviceProvider);
        sut.Invoking(s => s.GetRequiredService(null)).Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void GetRequiredService_unregistered_keyed_service_throws()
    {
        var serviceProvider = A.Fake<IKeyedServiceProvider>();
        object key = new();
        Exception ex = new("Foobar");

        A.CallTo(() => serviceProvider.GetRequiredKeyedService(typeof(IFoo), key))
            .Throws(ex);

        ServiceProvider<IFoo> sut = new(serviceProvider);

        sut.Invoking(s => s.GetRequiredService(key)).Should().Throw<Exception>()
            .Which.Should().Be(ex);
    }
}
