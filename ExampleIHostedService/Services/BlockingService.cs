namespace ExampleIHostedService.Services;

public class BlockingService : IHostedService
{
    private readonly ILogger<BlockingService> _logger;

    public BlockingService(ILogger<BlockingService> logger)
    {
        _logger = logger;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation(
            """
            BlockingHostedService startet. (warte 10 Sekunden)
            {Time}
            """, 
            DateTimeOffset.Now);
        
        await Task.Delay(TimeSpan.FromSeconds(10), cancellationToken);

        _logger.LogInformation(
            """
            BlockingHostedService abgeschlossen. 
            {Time}
            """, 
            DateTimeOffset.Now);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("BlockingHostedService wird gestoppt.");
        return Task.CompletedTask;
    }
}