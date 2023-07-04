namespace FkThat.Abstractions;

/// <summary>
/// <c cref="IConsole"/> extension methods.
/// </summary>
public static class ConsoleExtensions
{
    private static readonly string _newLine = Environment.NewLine;

    /// <summary>
    /// </summary>
    /// <param name="console">The <see cref="IConsole"/> instance.</param>
    /// <param name="value">The value to write.</param>
    public static void WriteLine(this IConsole console, string? value = null)
    {
        _ = console ?? throw new ArgumentNullException(nameof(console));

        if (value != null)
        {
            console.Write(value);
        }

        console.Write(_newLine);
    }

    /// <summary>
    /// </summary>
    /// <param name="console">The <see cref="IConsole"/> instance.</param>
    /// <param name="value">The value to write.</param>
    public static void WriteErrorLine(this IConsole console, string? value = null)
    {
        _ = console ?? throw new ArgumentNullException(nameof(console));

        if (value != null)
        {
            console.WriteError(value);
        }

        console.WriteError(_newLine);
    }
}
