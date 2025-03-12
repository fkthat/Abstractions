using Microsoft.Extensions.DependencyInjection;

namespace FkThat.Abstractions;

/// <inheritdoc/>
public sealed class ServiceProvider<T> : IServiceProvider<T> where T : class
{
    private readonly IServiceProvider _serviceProvider;

    /// <summary>
    /// Initialize a new instance of the <see cref="ServiceProvider{T}"/> class.
    /// </summary>
    /// <param name="serviceProvider"></param>
    public ServiceProvider(IServiceProvider serviceProvider)
    {
        ArgumentNullException.ThrowIfNull(serviceProvider);
        _serviceProvider = serviceProvider;
    }

    /// <inheritdoc/>
    public T? GetService(object? key = null) =>
        key != null ? _serviceProvider.GetKeyedService<T>(key)
            : _serviceProvider.GetService<T>();

    /// <inheritdoc/>
    public T GetRequiredService(object? key = null) =>
        key != null ? _serviceProvider.GetRequiredKeyedService<T>(key)
            : _serviceProvider.GetRequiredService<T>();
}
