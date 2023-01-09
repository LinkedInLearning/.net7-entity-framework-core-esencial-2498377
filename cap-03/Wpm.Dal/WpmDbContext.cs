using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Wpm.Domain;

namespace Wpm.Dal;
public class WpmDbContext : DbContext
{
    private string connectionString;
    public DbSet<Species> Species { get; set; }
    public DbSet<Pet> Pets { get; set; }
    public DbSet<Breed> Breeds { get; set; }

    public WpmDbContext()
    {
        connectionString = @"Data source=DESKTOP-F1HJ3VT\SQLEXPRESS;Initial Catalog=Wpm;Integrated Security=True;Trust Server Certificate=true";
    }

    public WpmDbContext(IConfiguration configuration)
    {
        connectionString = configuration.GetConnectionString("Wpm");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString);
    }
}
