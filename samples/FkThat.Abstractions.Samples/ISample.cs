namespace FkThat.Abstractions.Samples;

internal interface ISample
{
    Task RunAsync(CancellationToken cancellationToken = default);
}
