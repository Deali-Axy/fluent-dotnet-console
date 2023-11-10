# Fluent Dotnet Console

提供「现代化的控制台应用的开发体验」脚手架，能像 Web 应用那样很优雅地整合各种组件，包括依赖注入、配置、日志等功能。

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

## 项目目录结构

使用模板创建的项目目录结构是这样，代码统一放在 `src` 目录下。

```sql
MyProject
 ├─ src
 │  ├─ Utilities
 │  │  └─ ConsoleTool.cs
 │  ├─ Services
 │  │  ├─ MainService.cs
 │  │  └─ IService.cs
 │  ├─ MISC
 │  │  └─ SourceGenerationContext.cs
 │  ├─ Entities
 │  │  ├─ OutputResult.cs
 │  │  └─ AppSettings.cs
 │  └─ Program.cs
 ├─ MyProject.csproj
 ├─ Dockerfile
 └─ appsettings.json
```

这是 `src` 里每个目录的介绍：

- `Utilities`  - 存放通用工具类
- `Services` - 业务逻辑代码
- `MISC` - 杂项
- `Entities` - 实体类，强类型配置、输出结果对象

因此，创建项目之后，直接在 `Services/MainService.cs` 文件里写业务逻辑就好了。









