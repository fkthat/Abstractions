using System.Globalization;

namespace FkThat.Abstractions.Tests;

public sealed class ConsoleExtensionsTests
{
    [Fact]
    public async Task Write_methods_should_check_null_console()
    {
        IConsole console = null!;

        await FluentActions.Invoking(() => console.WriteLineAsync())
            .Should().ThrowAsync<ArgumentNullException>()
            .WithParameterName(nameof(console));

        // with string

        await FluentActions.Invoking(() => console.WriteAsync("foo"))
            .Should().ThrowAsync<ArgumentNullException>()
            .WithParameterName(nameof(console));

        await FluentActions.Invoking(() => console.WriteLineAsync("foo"))
            .Should().ThrowAsync<ArgumentNullException>()
            .WithParameterName(nameof(console));

        // with IFormattable

        await FluentActions.Invoking(() => console.WriteAsync(default(int)))
            .Should().ThrowAsync<ArgumentNullException>()
            .WithParameterName(nameof(console));

        await FluentActions.Invoking(() => console.WriteLineAsync(default(int)))
            .Should().ThrowAsync<ArgumentNullException>()
            .WithParameterName(nameof(console));

        await FluentActions.Invoking(() => console.WriteAsync(
                default(int), CultureInfo.InvariantCulture))
            .Should().ThrowAsync<ArgumentNullException>()
            .WithParameterName(nameof(console));

        await FluentActions.Invoking(() => console.WriteLineAsync(
                default(int), CultureInfo.InvariantCulture))
            .Should().ThrowAsync<ArgumentNullException>()
            .WithParameterName(nameof(console));

        // with object

        await FluentActions.Invoking(() => console.WriteAsync(default(object)!))
            .Should().ThrowAsync<ArgumentNullException>()
            .WithParameterName(nameof(console));

        await FluentActions.Invoking(() => console.WriteLineAsync(default(object)!))
            .Should().ThrowAsync<ArgumentNullException>()
            .WithParameterName(nameof(console));

        await FluentActions.Invoking(() => console.WriteAsync(
                default(object)!, CultureInfo.InvariantCulture))
            .Should().ThrowAsync<ArgumentNullException>()
            .WithParameterName(nameof(console));

        await FluentActions.Invoking(() => console.WriteLineAsync(
                default(object)!, CultureInfo.InvariantCulture))
            .Should().ThrowAsync<ArgumentNullException>()
            .WithParameterName(nameof(console));
    }

    [Fact]
    public async Task WriteAsync_should_check_null_value()
    {
        var console = A.Fake<IConsole>();

        // with string

        await console.Invoking(c => c.WriteAsync(default(string)!))
            .Should().ThrowAsync<ArgumentNullException>()
            .WithParameterName("value");

        await console.Invoking(c => c.WriteLineAsync(default(string)!))
            .Should().ThrowAsync<ArgumentNullException>()
            .WithParameterName("value");

        // with object

        await console.Invoking(c => c.WriteAsync(default(object)!))
            .Should().ThrowAsync<ArgumentNullException>()
            .WithParameterName("value");

        await console.Invoking(c => c.WriteLineAsync(default(object)!))
            .Should().ThrowAsync<ArgumentNullException>()
            .WithParameterName("value");

        await console.Invoking(c => c.WriteAsync(
            default(object)!, CultureInfo.InvariantCulture))
            .Should().ThrowAsync<ArgumentNullException>()
            .WithParameterName("value");

        await console.Invoking(c => c.WriteLineAsync(
            default(object)!, CultureInfo.InvariantCulture))
            .Should().ThrowAsync<ArgumentNullException>()
            .WithParameterName("value");
    }

    [Fact]
    public async Task WriteAsync_should_check_null_format_provider()
    {
        var console = A.Fake<IConsole>();

        // with IFormattable

        await FluentActions.Invoking(() => console.WriteAsync(
                default(int), default(IFormatProvider)!))
            .Should().ThrowAsync<ArgumentNullException>()
            .WithParameterName("formatProvider");

        await FluentActions.Invoking(() => console.WriteLineAsync(
                default(int), default(IFormatProvider)!))
            .Should().ThrowAsync<ArgumentNullException>()
            .WithParameterName("formatProvider");

        // with object

        await FluentActions.Invoking(() => console.WriteAsync(
                new object(), default(IFormatProvider)!))
            .Should().ThrowAsync<ArgumentNullException>()
            .WithParameterName("formatProvider");

        await FluentActions.Invoking(() => console.WriteLineAsync(
                new object(), default(IFormatProvider)!))
            .Should().ThrowAsync<ArgumentNullException>()
            .WithParameterName("formatProvider");
    }

    [Fact]
    public async Task WriteLineAsync_without_args_should_write_new_line()
    {
        StringWriter outTextWriter = new();
        var console = A.Fake<IConsole>();
        A.CallTo(() => console.Out).Returns(outTextWriter);

        await console.WriteLineAsync();

        outTextWriter.ToString().Should().Be(Environment.NewLine);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task WriteAsync_with_string_should_write_string(bool addNewLine)
    {
        StringWriter outTextWriter = new();
        var console = A.Fake<IConsole>();
        A.CallTo(() => console.Out).Returns(outTextWriter);

        if (addNewLine)
        {
            await console.WriteLineAsync("foobar");
        }
        else
        {
            await console.WriteAsync("foobar");
        }

        outTextWriter.ToString().Should().Be(
            addNewLine ? $"foobar{Environment.NewLine}" : "foobar");
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task WriteAsync_with_formattable_should_write_value(bool addNewLine)
    {
        StringWriter outTextWriter = new();
        var console = A.Fake<IConsole>();
        A.CallTo(() => console.Out).Returns(outTextWriter);
        DateTimeOffset value = new(2023, 6, 27, 22, 59, 25, TimeSpan.FromHours(3));
        var formatProvider = CultureInfo.GetCultureInfo("ru-RU");

        if (addNewLine)
        {
            await console.WriteLineAsync(value, formatProvider);
        }
        else
        {
            await console.WriteAsync(value, formatProvider);
        }

        outTextWriter.ToString().Should().Be(addNewLine ?
            $"27.06.2023 22:59:25 +03:00{Environment.NewLine}"
            : "27.06.2023 22:59:25 +03:00");
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task WriteAsync_with_formattable_and_default_format_should_write_value(bool addNewLine)
    {
        StringWriter outTextWriter = new();
        var console = A.Fake<IConsole>();
        A.CallTo(() => console.Out).Returns(outTextWriter);
        DateTimeOffset value = new(2023, 6, 27, 22, 59, 25, TimeSpan.FromHours(3));

        CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("ru-RU");

        if (addNewLine)
        {
            await console.WriteLineAsync(value);
        }
        else
        {
            await console.WriteAsync(value);
        }

        outTextWriter.ToString().Should().Be(addNewLine ?
            $"27.06.2023 22:59:25 +03:00{Environment.NewLine}"
            : "27.06.2023 22:59:25 +03:00");
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task WriteAsync_with_object_should_write_value(bool addNewLine)
    {
        StringWriter outTextWriter = new();
        var console = A.Fake<IConsole>();
        A.CallTo(() => console.Out).Returns(outTextWriter);
        object value = new DateTimeOffset(2023, 6, 27, 22, 59, 25, TimeSpan.FromHours(3));
        var formatProvider = CultureInfo.GetCultureInfo("ru-RU");

        if (addNewLine)
        {
            await console.WriteLineAsync(value, formatProvider);
        }
        else
        {
            await console.WriteAsync(value, formatProvider);
        }

        outTextWriter.ToString().Should().Be(addNewLine ?
            $"27.06.2023 22:59:25 +03:00{Environment.NewLine}"
            : "27.06.2023 22:59:25 +03:00");
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task WriteAsync_with_object_and_default_format_should_write_value(bool addNewLine)
    {
        StringWriter outTextWriter = new();
        var console = A.Fake<IConsole>();
        A.CallTo(() => console.Out).Returns(outTextWriter);
        object value = new DateTimeOffset(2023, 6, 27, 22, 59, 25, TimeSpan.FromHours(3));

        CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("ru-RU");

        if (addNewLine)
        {
            await console.WriteLineAsync(value);
        }
        else
        {
            await console.WriteAsync(value);
        }

        outTextWriter.ToString().Should().Be(addNewLine ?
            $"27.06.2023 22:59:25 +03:00{Environment.NewLine}"
            : "27.06.2023 22:59:25 +03:00");
    }

    [Fact]
    public async Task ReadKeyAsync_should_check_null_console()
    {
        IConsole console = null!;

        await FluentActions.Invoking(() => console.ReadKeyAsync())
            .Should().ThrowAsync<ArgumentNullException>().WithParameterName(nameof(console));

        await FluentActions.Invoking(() => console.ReadKeyAsync(TimeSpan.FromSeconds(1)))
            .Should().ThrowAsync<ArgumentNullException>().WithParameterName(nameof(console));
    }

    [Fact]
    public async Task ReadKeyAsync_should_return_key_info()
    {
        var console = A.Fake<IConsole>();
        A.CallTo(() => console.KeyAvailable).Returns(false).Once().Then.Returns(true);
        var keyInfo = new ConsoleKeyInfo('q', ConsoleKey.Q, true, true, true);
        A.CallTo(() => console.ReadKey(true)).Returns(keyInfo);

        var actual = await console.ReadKeyAsync(true);

        actual.Should().BeEquivalentTo(keyInfo);
    }
}
