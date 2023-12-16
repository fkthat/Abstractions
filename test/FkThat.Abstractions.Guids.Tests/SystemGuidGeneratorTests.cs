namespace FkThat.Abstractions.Guids;

public class SystemGuidGeneratorTests
{
    [Fact]
    public void NewGuid_should_return_unique_values()
    {
        SystemGuidGenerator sut = new();
        IEnumerable<Guid> r = Enumerable.Repeat(0, 42).Select(_ => sut.NewGuid());
        r.Should().OnlyHaveUniqueItems();
    }
}
