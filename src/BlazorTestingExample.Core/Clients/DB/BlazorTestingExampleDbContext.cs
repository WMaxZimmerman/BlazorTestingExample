using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace BlazorTestingExample.Core.Clients.DB;

public class BlazorTestingExampleDbContext: DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var host = "localhost";
        var db = "blazor_testing_example";
        var user = "postgres";
        var pass = "password";
        var connString = $"Host={host};Database={db};Username={user};Password={pass}";
        optionsBuilder.UseNpgsql(connString).UseSnakeCaseNamingConvention();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<User.User> Users { get; set; } = null!;
}