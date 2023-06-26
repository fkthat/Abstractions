namespace FkThat.Abstractions;

/// <summary>
/// Standard GUID generator.
/// </summary>
public class SystemGuidGenerator : IGuidGenerator
{
    ///<inheritdoc/>
    public Guid NewGuid() => Guid.NewGuid();
}
