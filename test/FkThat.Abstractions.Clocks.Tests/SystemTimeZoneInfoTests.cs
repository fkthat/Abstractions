namespace FkThat.Abstractions.Clocks;

public class SystemTimeZoneInfoTests
{
    [Fact]
    public void Local_should_return_local_time_zone()
    {
        SystemTimeZoneInfo sut = new();
        sut.Local.Should().Be(TimeZoneInfo.Local);
    }
}
