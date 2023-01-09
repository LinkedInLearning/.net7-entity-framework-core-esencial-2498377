using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Wpm.Domain;

namespace Wpm.Dal;
public class WpmDbContext : DbContext
{
    private string? connectionString;
    public DbSet<Species> Species { get; set; }
    public DbSet<Pet> Pets { get; set; }
    public DbSet<Breed> Breeds { get; set; }
    public DbSet<Owner> Owners { get; set; }

    public WpmDbContext(IConfiguration configuration)
    {
        connectionString = configuration.GetConnectionString("Wpm");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Owner>().HasData(
                    new Owner() { Id = 1, Name = "Rodrigo" },
                    new Owner() { Id = 2, Name = "Leonardo" },
                    new Owner() { Id = 3, Name = "Alicia" },
                    new Owner() { Id = 4, Name = "Jon" },
                    new Owner() { Id = 5, Name = "Elmer" },
                    new Owner() { Id = 6, Name = "Sam" },
                    new Owner() { Id = 7, Name = "Jessica" }
                    );
        modelBuilder.Entity<Species>().HasData(
                    new Species() { Id = 1, Name = "Perro" },
                    new Species() { Id = 2, Name = "Gato" },
                    new Species() { Id = 3, Name = "Conejo" }
                    );
        modelBuilder.Entity<Breed>().HasData(
                    new Breed() { Id = 1, Name = "Beagle", SpeciesId = 1 },
                    new Breed() { Id = 2, Name = "Pitbull", SpeciesId = 1 },
                    new Breed() { Id = 3, Name = "British Shorthair", SpeciesId = 2 },
                    new Breed() { Id = 4, Name = "Mixed", SpeciesId = 2 },
                    new Breed() { Id = 5, Name = "Gray", SpeciesId = 3 },
                    new Breed() { Id = 6, Name = "American White", SpeciesId = 3 }
                    );
        modelBuilder.Entity<Pet>().HasData(
                    new Pet() { Id = 1, Name = "Gianni", Age = 10, Weight = 19, BreedId = 1 },
                    new Pet() { Id = 2, Name = "Nina", Age = 8, Weight = 24, BreedId = 1 },
                    new Pet() { Id = 3, Name = "Cati", Age = 8, Weight = 33.5m, BreedId = 2 },
                    new Pet() { Id = 4, Name = "Cheshire Cat", Age = 20, Weight = 12, BreedId = 3 },
                    new Pet() { Id = 5, Name = "Garfield", Age = 20, Weight = 12, BreedId = 4 },
                    new Pet() { Id = 6, Name = "Bugs Bunny", Age = 40, Weight = 25, BreedId = 5 },
                    new Pet() { Id = 7, Name = "Roger Rabbit", Age = 35, Weight = 31, BreedId = 6 }
                    );
        modelBuilder.Entity("OwnerPet").HasData(
                    new[]
                    {
                                new { PetsId = 1, OwnersId = 1 },
                                new { PetsId = 1, OwnersId = 2 },
                                new { PetsId = 2, OwnersId = 1 },
                                new { PetsId = 2, OwnersId = 2 },
                                new { PetsId = 3, OwnersId = 1 },
                                new { PetsId = 3, OwnersId = 2 },
                                new { PetsId = 4, OwnersId = 3 },
                                new { PetsId = 5, OwnersId = 4 },
                                new { PetsId = 6, OwnersId = 5 },
                                new { PetsId = 6, OwnersId = 6 },
                                new { PetsId = 7, OwnersId = 7 },
                    }
                );
    }
}