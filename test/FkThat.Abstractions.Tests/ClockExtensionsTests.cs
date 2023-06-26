using System.Globalization;

namespace FkThat.Abstractions.Tests;

public class ClockExtensionsTests
{
    [Fact]
    public void GetLocalNow_should_check_null_clock()
    {
        IClock clock = null!;
        FluentActions.Invoking(() => ClockExtensions.GetLocalNow(clock))
            .Should().Throw<ArgumentNullException>()
            .Which.ParamName.Should().Be(nameof(clock));
    }

    [Theory]
    // regular time
    [InlineData("W. Europe Standard Time", "03/26/2023 00:00:59 +00:00", "03/26/2023 01:00:59 +01:00")]
    // summer time
    [InlineData("W. Europe Standard Time", "03/26/2023 01:00:01 +00:00", "03/26/2023 03:00:01 +02:00")]
    public void GetLocalNow_should_return_local_time(string timeZone, string utcNow, string localNow)
    {
        var clock = A.Fake<IClock>();
        IClock sut = clock;

        var tz = TimeZoneInfo.FindSystemTimeZoneById(timeZone);
        A.CallTo(() => clock.LocalTimeZone).Returns(tz);

        // just before the summer time transition
        A.CallTo(() => clock.GetUtcNow()).Returns(
            DateTimeOffset.Parse(utcNow, CultureInfo.InvariantCulture));

        var actualLocalNow = sut.GetLocalNow();

        actualLocalNow.ToString(CultureInfo.InvariantCulture).Should().Be(localNow);
    }
}
