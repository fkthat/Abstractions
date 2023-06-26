namespace FkThat.Abstractions.Tests;

public class SystemClockTests
{
    [Fact]
    public async Task GetUtcNow_should_return_incremental_time()
    {
        SystemClock sut = new();

        List<DateTimeOffset> r = new();

        for (var i = 0; i < 16; i++)
        {
            r.Add(sut.GetUtcNow());
            await Task.Delay(1).ConfigureAwait(false);
        }

        r.Should().BeInAscendingOrder();
    }

    [Fact]
    public void UtcNow_should_return_UTC_time()
    {
        SystemClock sut = new();
        sut.GetUtcNow().Offset.Should().Be(TimeSpan.Zero);
    }

    [Fact]
    public void TimeZone_should_return_local_time_zone()
    {
        SystemClock sut = new();
        sut.LocalTimeZone.Should().Be(TimeZoneInfo.Local);
    }
}
