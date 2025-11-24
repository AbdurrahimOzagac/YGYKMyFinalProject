using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework;

public class ApplicationDbContext : DbContext
{
    // Uses environment variable when available to avoid hard-coding secrets.
    private const string DefaultConnectionString =
        "Host=localhost;Port=5432;Database=myfinalproject;Username=postgres;Password=postgres";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString =
                Environment.GetEnvironmentVariable("POSTGRES_CONNECTION_STRING") ?? DefaultConnectionString;
            optionsBuilder.UseNpgsql(connectionString);
        }
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Customer> Customers { get; set; }
}
