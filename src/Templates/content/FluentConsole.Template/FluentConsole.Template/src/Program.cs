// See https://aka.ms/new-console-template for more information

using System;
using dotenv.net;
using FluentConsole.Template.Entities;
using FluentConsole.Template.Services;
using FluentConsole.Template.Utilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

DotEnv.Load();

ConsoleTool.PrintLogo();
ConsoleTool.PrintTitle("FluentConsole.Template - v1.0");

IConfigurationRoot? config;

var configBuilder = new ConfigurationBuilder();
configBuilder.AddEnvironmentVariables();
configBuilder.SetBasePath(Environment.CurrentDirectory);
configBuilder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: false);
try {
    config = configBuilder.Build();
}
catch (Exception ex) {
    Console.WriteLine($"配置文件加载失败！请检查配置文件是不是哪里写错了？\n错误信息：{ex.Message}");
    return;
}


Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.File("logs/fluent-demo-logs.log")
    .CreateLogger();


var services = new ServiceCollection();
services.AddLogging(builder => {
    builder.AddConfiguration(config.GetSection("Logging"));
    builder.AddConsole();
    builder.AddSerilog(dispose: true);
});
services.AddSingleton<IConfiguration>(config);
services.AddOptions().Configure<AppSettings>(e => config.GetSection(nameof(AppSettings)).Bind(e));
services.AddScoped<MainService>();

await using (var sp = services.BuildServiceProvider()) {
    var service = sp.GetRequiredService<MainService>();
    service.Run();
}

Console.Read();