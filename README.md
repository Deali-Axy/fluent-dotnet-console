# Fluent Dotnet Console

提供「现代化的控制台应用的开发体验」脚手架，能像 Web 应用那样很优雅地整合各种组件，包括依赖注入、配置、日志等功能。

---

[![NuGet](https://img.shields.io/nuget/v/FluentConsole.Templates.svg)](https://www.nuget.org/packages/FluentConsole.Templates/)
[![Build Status](https://img.shields.io/github/actions/workflow/status/Deali-Axy/fluent-dotnet-console/dotnet.yml)](https://github.com/Deali-Axy/fluent-dotnet-console/actions)
[![License](https://img.shields.io/github/license/Deali-Axy/fluent-dotnet-console.svg)](https://github.com/Deali-Axy/fluent-dotnet-console/blob/master/README.md)
[![GitHub issues](https://img.shields.io/github/issues/Deali-Axy/fluent-dotnet-console.svg)](https://github.com/Deali-Axy/fluent-dotnet-console/issues)
[![GitHub forks](https://img.shields.io/github/forks/Deali-Axy/fluent-dotnet-console.svg)](https://github.com/Deali-Axy/fluent-dotnet-console/network)
[![GitHub stars](https://img.shields.io/github/stars/Deali-Axy/fluent-dotnet-console.svg)](https://github.com/Deali-Axy/fluent-dotnet-console/stargazers)


## Features

- 🚀 提供快速开发模板，一键生成控制台应用的项目骨架
- 🐴 提供一个「现代化控制台应用项目结构的最佳实践」的参考方案
- 💉 依赖注入 - 基于 `Microsoft.Extensions.DependencyInjection` 的依赖注入支持
- 📄 日志 - 基于 `Microsoft.Extensions.Logging` 日志框架，搭配 `Serilog` 实现日志文件输出
- 🔧 配置 - 基于 `Microsoft.Extensions.Configuration` 配置框架，搭配 `dotenv.net` 等组件扩展功能
- 🚗 数据库 (beta) - 基于 EFCore 实现数据库操作

## Quick Start

安装模板

```bash
dotnet new install FluentConsole.Templates
```

使用模板创建项目

```bash
dotnet new flu-cli -n MyProject
```

`Program.cs` 代码

```c#
var builder = FluentConsoleApp.CreateBuilder(args);
var app = builder.Build();
await app.Run<MainService>();
```

## 项目目录结构

使用模板创建的项目目录结构是这样，代码统一放在 `src` 目录下。

```
 MyProject
 ├─ src
 │  ├─ Utilities
 │  │  ├─ SourceGenerationContext.cs
 │  │  └─ ConsoleTool.cs
 │  ├─ Services
 │  │  ├─ MainService.cs
 │  │  └─ IService.cs
 │  ├─ Framework
 │  │  ├─ Extensions
 │  │  │  └─ FluentConsoleBuilderExt.cs
 │  │  ├─ FluentConsoleBuilder.cs
 │  │  └─ FluentConsoleApp.cs
 │  ├─ Entities
 │  │  ├─ OutputResult.cs
 │  │  └─ AppSettings.cs
 │  └─ Program.cs
 ├─ MyProject.csproj
 ├─ Dockerfile
 ├─ .env
 └─ appsettings.json
```

这是 `src` 里每个目录的介绍：

- `Utilities`  - 存放通用工具类
- `Services` - 业务逻辑代码
- `Framework` - 框架核心代码，一般不需要修改
- `Entities` - 实体类，强类型配置、输出结果对象

创建项目之后，可以在 `Services` 目录里写业务逻辑，实现 `IService` 接口的类会自动注册。

## Build

直接在代码里安装模板进行测试

```bash
dotnet new install ./src/Templates/content/FluentConsole.Template
```

## EFCore 支持 (beta)

> PS：这个是实验性功能，后续版本可能会有调整。

2.3 版本开始引入 EFCore 支持。

默认不启用，需要请手动开启

编辑 `Program.cs` 文件

```c#
using FluentConsole.Template.Services;
using FluentConsole.Template.Framework;
using FluentConsole.Template.Framework.Extensions;

var builder = FluentConsoleApp.CreateBuilder(args);
var app = builder.Build();

// 添加这行代码开启默认的 EFCore 支持
app.AddDefaultEFCoreItegration();

await app.Run<MainService>();

Console.Read();
```

默认使用 SQLite 数据库

如果想使用其他数据库请自行添加驱动和配置

直接在 Program.cs 里编辑即可

```c#
 app.Services.AddDbContext<AppDbContext>(options => {
     options.UseSqlite(app.Configuration.GetConnectionString("SQLite"));
 });
```

### DesignTime 配置

开发阶段的迁移和数据库同步操作依赖于 Data/AppDesignTimeDbContextFactory.cs 的配置

默认配置使用的是 SQLite 数据库，从环境变量读取数据库连接字符串，如果读不到就使用默认的数据库文件。

```c#
public class AppDesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext> {
    public AppDbContext CreateDbContext(string[] args) {
        var builder = new DbContextOptionsBuilder<AppDbContext>();

        var connStr = Environment.GetEnvironmentVariable("CONNECTION_STRING");
        if (connStr == null) {
            var dbpath = Path.Combine(Environment.CurrentDirectory, "app.db");
            connStr = $"Data Source={dbpath};";
        }

        builder.UseSqlite(connStr);
        return new AppDbContext(builder.Options);
    }
}
```

如果切换了数据库，请根据实际需求修改这个配置。

### 迁移和同步

使用以下命令迁移

```bash
dotnet ef migrations add InitialCreate -o .\src\Data\Migrations
```

同步数据库

```bash
dotnet ef database update
```

### db-first

从已有数据库生成实体类，EFCore 的 cli tool 提供了很丰富的代码生成功能。

这里提供一下例子：

- 使用 PostgreSql 数据库，要把其中 `pe_shit_data` 库的所有表生成实体类
- 生成的 `DbContext` 类名为 `ShitDbContext`
- `DbContext` 类的命名空间为 `PE.Data`
- 实体类放在 `Data/ShitModels` 目录下，命名空间为 `PE.Data.ShitModels`

Powershell 命令如下

```powershell
dotnet ef dbcontext scaffold `
    "Host=localhost;Database=pe_shit_data;Username=postgres;Password=passw0rd" `
    Npgsql.EntityFrameworkCore.PostgreSQL `
    -f `
    -c ShitDbContext `
    --context-dir . `
    --context-namespace PE.Data `
    -o Data/ShitModels `
    --namespace PE.Data.ShitModels
```

这个是 powershell 的命令，如果是 Linux 环境，把每一行命令末尾的反引号换成 `\` 即可。

### 实践建议

请在 Data/Models 目录下定义数据模型，并在 Data/Config 添加对应的实体类配置。

虽然也可以用 Data Annotation 来配置，但 EFCore 推荐使用 Fluent Config 方式来配置数据表和字段。

#### 主键类型选择

这里插播一下题外话，关于主键类型应该如何选择。

目前主要有几种方式：

- 自增
- GUID
- 自增+GUID
- Hi/Lo

这几种方式各有优劣。

- 自增的好处是简单，缺点是在数据库迁移或者分布式系统中容易出问题，而且高并发时插入性能较差。
- GUID好处也是简单方便，而且也适用于分布式系统；MySQL的InnoDB引擎强制主键使用聚集索引，导致新插入的每条数据都要经历查找合适插入位置的过程，在数据量大的时候插入性能很差。
- 自增+GUID是把自增字段作为物理主键，GUID作为逻辑主键，可以在一定程度上解决上述两种方式的问题。
- Hi/Lo可以优化自增列的性能，但只有部分数据库支持，比如SQL Server，其他的数据库暂时还没研究。

### 推荐阅读

- [Asp-Net-Core开发笔记：快速在已有项目中引入EFCore](https://www.cnblogs.com/deali/p/17749676.html)
- [Asp-Net-Core开发笔记：EFCore统一实体和属性命名风格](https://www.cnblogs.com/deali/p/17751279.html)

## Todos

- [ ] 添加 .gitignore 和 .editorconfig 文件

## updates

### 2.3

- fix: 解决创建后目录嵌套的问题
- feature: 集成 EFCore 支持
- add:  .gitignore 和 .editorconfig 文件

### 2.2

- 更新一些依赖；依然使用 .Net8 版本

### 2.1

- 修复 `FluentConsoleApp.Run<T>` 的bug

### 2.0

- 升级到 .Net8 版本
- 添加 `Microsoft.Extensions.Caching.Abstractions` 依赖
- 添加 `Flurl.Http` 为程序提供强大的网络访问能力
- 删除 `FluentConsole.Template.MISC` 命名空间
- 重构框架，优化 `Program.cs` 文件的代码，现在更简洁了
- 封装了框架逻辑，相关代码在 `Framework` 目录下，隐藏了初始化逻辑
- 自动服务注册，只要实现了 `IService` 接口的服务，就会自动扫描并注册





