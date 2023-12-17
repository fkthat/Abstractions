namespace FkThat.Abstractions.Guids;

public class V7GuidTimestampTests
{
    [Theory]
    [InlineData(0, 0, V7GuidSubsecondPrecision.Millisescond, 0)]
    [InlineData(0, 0, V7GuidSubsecondPrecision.Microsecond, 0)]
    [InlineData(0, 0, V7GuidSubsecondPrecision.Nanosecond, 0)]
    [InlineData(63838409075, 333, V7GuidSubsecondPrecision.Millisescond, 638384090753330000)]
    [InlineData(63838409075, 333758, V7GuidSubsecondPrecision.Microsecond, 638384090753337580)]
    [InlineData(63838409075, 333758200, V7GuidSubsecondPrecision.Nanosecond, 638384090753337582)]
    public void Ticks_returns_correct_value(
        long unixts, long subsec, V7GuidSubsecondPrecision precision, long expected)
    {
        V7GuidTimestamp sut = new(unixts, subsec, precision);
        sut.Ticks.Should().Be(expected);
    }
}
