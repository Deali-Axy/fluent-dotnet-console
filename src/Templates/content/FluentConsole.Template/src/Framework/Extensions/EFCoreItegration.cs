using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FluentConsole.Template.Data;

namespace FluentConsole.Template.Framework.Extensions;

public static class EFCoreItegration {
    public static void AddDefaultEFCoreItegration(this FluentConsoleApp app) {
        app.Services.AddDbContext<AppDbContext>(options => {
            options.UseSqlite(app.Configuration.GetConnectionString("SQLite"));
        });
    }
}