namespace ExampleIHostedService.Services;

public class SimpleHostedService : IHostedService
{
    private readonly ILogger<SimpleHostedService> _logger;
    private Timer? _timer;

    public SimpleHostedService(ILogger<SimpleHostedService> logger)
    {
        _logger = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Service wird gestartet.");
        
        _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));

        return Task.CompletedTask;
    }

    private void DoWork(object? state)
    {
        _logger.LogInformation("Hintergrundarbeit läuft: {time}", DateTimeOffset.Now);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Service wird gestoppt.");

        _timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }
}