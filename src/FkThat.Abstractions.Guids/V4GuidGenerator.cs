namespace FkThat.Abstractions.Guids;

/// <summary>
/// Standard GUID generator.
/// </summary>
public sealed class V4GuidGenerator : IGuidGenerator
{
    ///<inheritdoc/>
    public Guid NewGuid() => Guid.NewGuid();
}
