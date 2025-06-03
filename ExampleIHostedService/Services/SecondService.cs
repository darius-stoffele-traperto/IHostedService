namespace ExampleIHostedService.Services;

public class SecondService : IHostedService
{
    private readonly ILogger<SecondService> _logger;

    public SecondService(ILogger<SecondService> logger)
    {
        _logger = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation(
            """
            SecondService startet. 
            {Time}
            """, 
            DateTimeOffset.Now);
        
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("SecondService wird gestoppt.");
        return Task.CompletedTask;
    }
}