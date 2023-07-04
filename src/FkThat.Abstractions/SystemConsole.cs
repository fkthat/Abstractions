using System.Diagnostics.CodeAnalysis;

namespace FkThat.Abstractions
{
    /// <summary>
    /// Represents the system console.
    /// </summary>
    public sealed class SystemConsole : IConsole
    {
        /// <inheritdoc/>
        public void Write(string value) => Console.Write(
            value ?? throw new ArgumentNullException(nameof(value)));

        /// <inheritdoc/>
        public void WriteError(string value) => Console.Error.Write(
            value ?? throw new ArgumentNullException(nameof(value)));

        /// <inheritdoc/>
        [ExcludeFromCodeCoverage]
        public ConsoleKeyInfo ReadKey(bool intercept = false) => Console.ReadKey(intercept);
    }
}
