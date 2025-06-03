var builder = Host.CreateDefaultBuilder(args)
    .UseConsoleLifetime(options => options.SuppressStatusMessages = true)
    .ConfigureServices(services =>
    {
        services.AddHostedService<BlockingService>();
        services.AddHostedService<SecondService>();
    });

await builder.Build().RunAsync();