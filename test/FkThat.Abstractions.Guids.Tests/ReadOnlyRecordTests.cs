namespace FkThat.Abstractions.Guids;

public class ReadOnlyRecordTests
{
    [Fact]
    public void CopyStruct()
    {
        Foo foo = new(1, "foo");
        Foo bar = new(2, "bar");
        bar = foo;

        bar.Should().BeEquivalentTo(new {
            Id = 1,
            Name = "foo"
        });

        bar.Should().Be(foo);
    }
}

readonly file record struct Foo(int Id, string Name);
