namespace FkThat.Abstractions.Tests;

public sealed class ConsoleExtensionsTests
{
    [Fact]
    public void WriteLine_should_check_null_console()
    {
        IConsole console = null!;

        FluentActions.Invoking(() => console.WriteLine("foo"))
            .Should().Throw<ArgumentNullException>()
            .WithParameterName(nameof(console));
    }

    [Fact]
    public void WriteLine_with_null_value_should_write_newline_to_stdout()
    {
        var console = A.Fake<IConsole>();
        StringWriter stdout = new StringWriter();

        A.CallTo(() => console.Write(A<string>._))
            .Invokes((string s) => stdout.Write(s));

        console.WriteLine(null);

        stdout.ToString().Should().Be($"{Environment.NewLine}");
    }

    [Fact]
    public void WriteLine_should_write_value_to_stdout()
    {
        var console = A.Fake<IConsole>();
        StringWriter stdout = new StringWriter();

        A.CallTo(() => console.Write(A<string>._))
            .Invokes((string s) => stdout.Write(s));

        console.WriteLine("foo");

        stdout.ToString().Should().Be($"foo{Environment.NewLine}");
    }

    [Fact]
    public void WriteErrorLine_should_check_null_console()
    {
        IConsole console = null!;

        FluentActions.Invoking(() => console.WriteErrorLine("foo"))
            .Should().Throw<ArgumentNullException>()
            .WithParameterName(nameof(console));
    }

    [Fact]
    public void WriteErrorLine_with_null_value_should_write_neline_to_stderr()
    {
        var console = A.Fake<IConsole>();
        StringWriter stderr = new StringWriter();

        A.CallTo(() => console.WriteError(A<string>._))
            .Invokes((string s) => stderr.Write(s));

        console.WriteErrorLine(null);

        stderr.ToString().Should().Be($"{Environment.NewLine}");
    }

    [Fact]
    public void WriteErrorLine_should_write_value_to_stdout()
    {
        var console = A.Fake<IConsole>();
        StringWriter stderr = new StringWriter();

        A.CallTo(() => console.WriteError(A<string>._))
            .Invokes((string s) => stderr.Write(s));

        console.WriteErrorLine("foo");

        stderr.ToString().Should().Be($"foo{Environment.NewLine}");
    }
}
