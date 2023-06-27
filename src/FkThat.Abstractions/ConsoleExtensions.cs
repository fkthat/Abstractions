using System.Globalization;

namespace FkThat.Abstractions;

/// <summary>
/// <c cref="IConsole"/> extension methods.
/// </summary>
public static class ConsoleExtensions
{
    /// <summary>
    /// Writes the new line string value to the standard output stream.
    /// </summary>
    /// <param name="console">The <c cref="IConsole"/> instance.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    public static async Task WriteLineAsync(
        this IConsole console,
        CancellationToken cancellationToken = default)
    {
        _ = console ?? throw new ArgumentNullException(nameof(console));

        await console.WriteAsync(Environment.NewLine, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Writes the specified string value to the standard output stream.
    /// </summary>
    /// <param name="console">The <c cref="IConsole"/> instance.</param>
    /// <param name="value">The value to write.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    public static async Task WriteAsync(
        this IConsole console,
        string value,
        CancellationToken cancellationToken = default)
    {
        _ = console ?? throw new ArgumentNullException(nameof(console));
        _ = value ?? throw new ArgumentNullException(nameof(value));

        await console.Out.WriteAsync(value.AsMemory(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Writes the specified string value with new line to the standard output stream.
    /// </summary>
    /// <param name="console">The <c cref="IConsole"/> instance.</param>
    /// <param name="value">The value to write.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    public static async Task WriteLineAsync(
        this IConsole console,
        string value,
        CancellationToken cancellationToken = default)
    {
        _ = console ?? throw new ArgumentNullException(nameof(console));
        _ = value ?? throw new ArgumentNullException(nameof(value));

        await console.WriteAsync(value, cancellationToken).ConfigureAwait(false);
        await console.WriteLineAsync(cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Writes the text representation of the specified value to the standard output stream.
    /// </summary>
    /// <typeparam name="T">The type of the <paramref name="value"/>.</typeparam>
    /// <param name="console">The <c cref="IConsole"/> instance.</param>
    /// <param name="value">The value to write.</param>
    /// <param name="formatProvider">The format provider.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    public static async Task WriteAsync<T>(
        this IConsole console,
        T value,
        IFormatProvider formatProvider,
        CancellationToken cancellationToken = default)
        where T : IFormattable
    {
        _ = console ?? throw new ArgumentNullException(nameof(console));
        _ = formatProvider ?? throw new ArgumentNullException(nameof(formatProvider));

        await console.WriteAsync(
            string.Format(formatProvider, "{0}", value),
            cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Writes the text representation of the specified value to the standard output stream.
    /// </summary>
    /// <typeparam name="T">The type of the <paramref name="value"/>.</typeparam>
    /// <param name="console">The <c cref="IConsole"/> instance.</param>
    /// <param name="value">The value to write.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    public static async Task WriteAsync<T>(
        this IConsole console,
        T value,
        CancellationToken cancellationToken = default)
        where T : struct, IFormattable
    {
        _ = console ?? throw new ArgumentNullException(nameof(console));

        await console.WriteAsync(value, CultureInfo.CurrentCulture, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Writes the text representation of the specified value to the standard output stream.
    /// </summary>
    /// <typeparam name="T">The type of the <paramref name="value"/>.</typeparam>
    /// <param name="console">The <c cref="IConsole"/> instance.</param>
    /// <param name="value">The value to write.</param>
    /// <param name="formatProvider">The format provider.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    public static async Task WriteLineAsync<T>(
        this IConsole console,
        T value,
        IFormatProvider formatProvider,
        CancellationToken cancellationToken = default)
        where T : IFormattable
    {
        _ = console ?? throw new ArgumentNullException(nameof(console));
        _ = formatProvider ?? throw new ArgumentNullException(nameof(formatProvider));

        await console.WriteAsync<T>(value, formatProvider, cancellationToken)
            .ConfigureAwait(false);

        await console.WriteAsync(Environment.NewLine, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Writes the text representation of the specified value to the standard output stream.
    /// </summary>
    /// <typeparam name="T">The type of the <paramref name="value"/>.</typeparam>
    /// <param name="console">The <c cref="IConsole"/> instance.</param>
    /// <param name="value">The value to write.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    public static async Task WriteLineAsync<T>(
        this IConsole console,
        T value,
        CancellationToken cancellationToken = default)
        where T : IFormattable
    {
        _ = console ?? throw new ArgumentNullException(nameof(console));

        await console.WriteLineAsync(value, CultureInfo.CurrentCulture, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Writes the text representation of the specified object to the standard output stream.
    /// </summary>
    /// <param name="console">The <c cref="IConsole"/> instance.</param>
    /// <param name="value">The value to write.</param>
    /// <param name="formatProvider">The format provider.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    public static async Task WriteAsync(
        this IConsole console,
        object value,
        IFormatProvider formatProvider,
        CancellationToken cancellationToken = default)
    {
        _ = console ?? throw new ArgumentNullException(nameof(console));
        _ = value ?? throw new ArgumentNullException(nameof(value));
        _ = formatProvider ?? throw new ArgumentNullException(nameof(formatProvider));

        await console.WriteAsync(
            string.Format(formatProvider, "{0}", value),
            cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Writes the text representation of the specified object to the standard output stream.
    /// </summary>
    /// <param name="console">The <c cref="IConsole"/> instance.</param>
    /// <param name="value">The value to write.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    public static async Task WriteAsync(
        this IConsole console,
        object value,
        CancellationToken cancellationToken = default)
    {
        _ = console ?? throw new ArgumentNullException(nameof(console));
        _ = value ?? throw new ArgumentNullException(nameof(value));

        await console.WriteAsync(value, CultureInfo.CurrentCulture, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Writes the text representation of the specified object to the standard output stream.
    /// </summary>
    /// <param name="console">The <c cref="IConsole"/> instance.</param>
    /// <param name="value">The value to write.</param>
    /// <param name="formatProvider">The format provider.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    public static async Task WriteLineAsync(
        this IConsole console,
        object value,
        IFormatProvider formatProvider,
        CancellationToken cancellationToken = default)
    {
        _ = console ?? throw new ArgumentNullException(nameof(console));
        _ = value ?? throw new ArgumentNullException(nameof(value));
        _ = formatProvider ?? throw new ArgumentNullException(nameof(formatProvider));

        await console.WriteAsync(value, formatProvider, cancellationToken)
            .ConfigureAwait(false);

        await console.WriteLineAsync(cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Writes the text representation of the specified object to the standard output stream.
    /// </summary>
    /// <param name="console">The <c cref="IConsole"/> instance.</param>
    /// <param name="value">The value to write.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    public static async Task WriteLineAsync(
        this IConsole console,
        object value,
        CancellationToken cancellationToken = default)
    {
        _ = console ?? throw new ArgumentNullException(nameof(console));
        _ = value ?? throw new ArgumentNullException(nameof(value));

        await console.WriteLineAsync(value, CultureInfo.CurrentCulture, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Obtains the next character or function key pressed by the user. The pressed key is
    /// optionally displayed in the console window.
    /// </summary>
    /// <param name="console">The <c cref="IConsole"/> instance.</param>
    /// <param name="intercept">
    /// Determines whether to display the pressed key in the console window. <see langword="true"/>
    /// to not display the pressed key; otherwise, <see langword="false"/>.
    /// </param>
    public static Task<ConsoleKeyInfo> ReadKeyAsync(this IConsole console, bool intercept = false)
    {
        _ = console ?? throw new ArgumentNullException(nameof(console));
        return console.ReadKeyAsync(TimeSpan.FromMilliseconds(10), intercept);
    }

    /// <summary>
    /// Obtains the next character or function key pressed by the user. The pressed key is
    /// optionally displayed in the console window.
    /// </summary>
    /// <param name="console">The <c cref="IConsole"/> instance.</param>
    /// <param name="pollInterval">
    /// The <see cref="TimeSpan"/> interval to poll the console keyboard.
    /// </param>
    /// <param name="intercept">
    /// Determines whether to display the pressed key in the console window. <see langword="true"/>
    /// to not display the pressed key; otherwise, <see langword="false"/>.
    /// </param>
    public static async Task<ConsoleKeyInfo> ReadKeyAsync(
        this IConsole console, TimeSpan pollInterval, bool intercept = false)
    {
        _ = console ?? throw new ArgumentNullException(nameof(console));

        while (!console.KeyAvailable)
        {
            await Task.Delay(pollInterval).ConfigureAwait(false);
        }

        return console.ReadKey(intercept);
    }
}
