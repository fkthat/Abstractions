using System.Diagnostics.CodeAnalysis;

namespace FkThat.Abstractions
{
    /// <summary>
    /// Represents the system console.
    /// </summary>
    public sealed class SystemConsole : IConsole
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
        public ConsoleKeyInfo ReadKey(bool intercept = false) => Console.ReadKey(intercept);
    }
}
