namespace FkThat.Abstractions;

/// <summary>
/// Retrieves services of the <typeparamref name="T"/> type using a key and a type.
/// </summary>
/// <typeparam name="T">The type of services to retrive.</typeparam>
public interface IServiceProvider<T> where T: class
{
    /// <summary>
    /// Gets the service object.
    /// </summary>
    /// <param name="key">An object that specifies the key of service object to get.</param>
    T? GetService(object? key = default);

    /// <summary>
    /// Gets the service object.
    /// </summary>
    /// <param name="key">An object that specifies the key of service object to get.</param>
    T GetRequiredService(object? key = default);
}
