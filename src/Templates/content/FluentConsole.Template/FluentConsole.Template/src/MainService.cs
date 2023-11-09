using System.IO;
using System.Text.Json;
using Dumpify;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FluentConsole.Template;

public class MainService {
    private readonly ILogger<MainService> _logger;
    private readonly AppSettings _settings;
    private readonly IConfiguration _conf;

    public MainService(ILogger<MainService> logger, IOptions<AppSettings> options, IConfiguration conf) {
        _logger = logger;
        _settings = options.Value;
        _conf = conf;
    }

    public void Run() {
        _logger.LogInformation("启动！");

        _logger.LogInformation("测试配置文件加载情况");
        _settings.Dump();

        _logger.LogDebug("读取 .env 里的环境变量: {EnvVar}", _conf["ENV_VAR1"]);

        _logger.LogInformation("输出JSON格式的结果");
        var result = new OutputResult {
            Result = "ok",
            Messages = new[] { "msg1", "msg2" }
        };
        File.WriteAllText("output.json",
            JsonSerializer.Serialize(result, SourceGenerationContext.Default.OutputResult));
    }
}