namespace FkThat.Abstractions;

using System.Diagnostics.CodeAnalysis;

using Console = System.Console;

/// <summary>
/// Represents the system console.
/// </summary>
public sealed class SystemConsole : IConsoleText, IConsoleBinary, IConsoleKeyboard
{
    /// <inheritdoc/>
    public TextReader In => Console.In;

    /// <inheritdoc/>
    public TextWriter Out => Console.Out;

    /// <inheritdoc/>
    public TextWriter Error => Console.Error;

    /// <inheritdoc/>
    [ExcludeFromCodeCoverage]
    public bool KeyAvailable => Console.KeyAvailable;

    /// <inheritdoc/>
    [ExcludeFromCodeCoverage]
    public Stream OpenStandardInput() => Console.OpenStandardInput();

    /// <inheritdoc/>
    [ExcludeFromCodeCoverage]
    public Stream OpenStandardOutput() => Console.OpenStandardOutput();

    /// <inheritdoc/>
    [ExcludeFromCodeCoverage]
    public Stream OpenStandardError() => Console.OpenStandardError();

    /// <inheritdoc/>
    [ExcludeFromCodeCoverage]
    public ConsoleKeyInfo ReadKey(bool intercept) => Console.ReadKey(intercept);
}
