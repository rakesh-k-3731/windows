using Microsoft.Extensions.Logging;
using RKC.Common.Lib.Core;

namespace RKC.Win.BackgroundService;

public sealed class Worker(ILogger<Worker> logger, IClock clock) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            logger.LogInformation("Background society sync executed at: {time}", clock.UtcNow);
            await Task.Delay(TimeSpan.FromMinutes(15), stoppingToken);
        }
    }
}
