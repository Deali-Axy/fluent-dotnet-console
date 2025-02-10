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

## updates

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





