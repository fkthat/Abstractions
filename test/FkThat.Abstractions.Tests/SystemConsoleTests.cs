namespace FkThat.Abstractions.Tests;

public sealed class SystemConsoleTests
{
    [Fact]
    public void Write_should_check_null_value()
    {
        SystemConsole sut = new();

        sut.Invoking(s => s.Write(null!))
            .Should().Throw<ArgumentNullException>()
            .WithParameterName("value");
    }

    [Fact]
    public void Write_should_write_value_to_stdout()
    {
        StringWriter stdout = new();

        var oldStdOut = Console.Out;
        Console.SetOut(stdout);

        try
        {
            SystemConsole sut = new();
            sut.Write("foo");

            stdout.ToString().Should().Be("foo");
        }
        finally
        {
            Console.SetOut(oldStdOut);
        }
    }

    [Fact]
    public void WriteError_should_check_null_value()
    {
        SystemConsole sut = new();

        sut.Invoking(s => s.WriteError(null!))
            .Should().Throw<ArgumentNullException>()
            .WithParameterName("value");
    }

    [Fact]
    public void WriteError_should_write_value_to_stderr()
    {
        StringWriter stderr = new();

        var oldStdErr = Console.Error;
        Console.SetError(stderr);

        try
        {
            SystemConsole sut = new();
            sut.WriteError("foo");

            stderr.ToString().Should().Be("foo");
        }
        finally
        {
            Console.SetOut(oldStdErr);
        }
    }
}
