using System.Diagnostics.CodeAnalysis;

namespace FkThat.Abstractions;

/// <summary>
/// Represents an abstract console.
/// </summary>
public interface IConsole
{
    /// <summary>
    /// Gets the standard input stream.
    /// </summary>
    [SuppressMessage("Naming", "CA1716:Identifiers should not match keywords", Justification =
        "Named to be consistent with System.Console.")]
    TextReader In { get; }

    /// <summary>
    /// Gets the standard output stream.
    /// </summary>
    TextWriter Out { get; }

    /// <summary>
    /// Gets the standard error stream.
    /// </summary>
    [SuppressMessage("Naming", "CA1716:Identifiers should not match keywords", Justification =
        "Named to be consistent with System.Console.")]
    TextWriter Error { get; }

    /// <summary>
    /// Gets a value indicating whether a key press is available in the input stream.
    /// </summary>
    bool KeyAvailable { get; }

    /// <summary>
    /// Obtains the next character or function key pressed by the user. The pressed key is
    /// optionally displayed in the console window.
    /// </summary>
    /// <param name="intercept">
    /// Determines whether to display the pressed key in the console window. <see langword="true"/>
    /// to not display the pressed key; otherwise, <see langword="false"/>.
    /// </param>
    ConsoleKeyInfo ReadKey(bool intercept = false);
}
