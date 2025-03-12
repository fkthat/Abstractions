using System.Diagnostics.CodeAnalysis;

namespace FkThat.Abstractions;

/// <summary>
/// The keys for various <see cref="IRandomGenerator"/> implementations.
/// </summary>
[ExcludeFromCodeCoverage]
public static class RandomGeneratorServiceKey
{
    /// <summary>
    /// <see cref="PseudoRandomGenerator"/> service key.
    /// </summary>
    public static readonly object Pseudo = new();

    /// <summary>
    /// <see cref="CryptoRandomGenerator"/> service key.
    /// </summary>
    public static readonly object Crypto = new();
}
