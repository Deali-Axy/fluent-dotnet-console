// See https://aka.ms/new-console-template for more information

using FluentConsole.Template.Services;
using FluentConsole.Template.Framework;

var builder = FluentConsoleApp.CreateBuilder(args);
var app = builder.Build();

await app.Run<MainService>();

Console.Read();