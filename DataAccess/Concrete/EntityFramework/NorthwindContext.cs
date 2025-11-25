using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;


namespace DataAccess.Concrete.EntityFramework;

public class NorthwindContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var cs = Environment.GetEnvironmentVariable("POSTGRES_CONNECTION_STRING")
                 ?? throw new InvalidOperationException("POSTGRES_CONNECTION_STRING not set");
        optionsBuilder.UseNpgsql(cs);
        optionsBuilder.UseSnakeCaseNamingConvention();
    }

    // configure Products table


    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Customer> Customers { get; set; }

}