using FluentConsole.Template.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FluentConsole.Template.Data;

public class AppDbContext : DbContext {
    public DbSet<AuditLog> AuditLogs { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSnakeCaseNamingConvention();
    }
}