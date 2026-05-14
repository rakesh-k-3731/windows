using RKC.Common.Lib.Core;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddSingleton<IClock, SystemClock>();
builder.Services.AddHostedService<RKC.Win.BackgroundService.Worker>();

var host = builder.Build();
host.Run();
