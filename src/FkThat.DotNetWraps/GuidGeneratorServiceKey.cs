using System.Diagnostics.CodeAnalysis;

namespace FkThat.Abstractions;

/// <summary>
/// The keys for various <see cref="IGuidGenerator"/> implementations.
/// </summary>
[ExcludeFromCodeCoverage]
public static class GuidGeneratorServiceKey
{
    /// <summary>
    /// <see cref="V4GuidGenerator"/> service key.
    /// </summary>
    public static readonly object V4 = new();

    /// <summary>
    /// <see cref="V7GuidGenerator"/> service key.
    /// </summary>
    public static readonly object V7 = new();
}
