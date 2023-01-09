using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Wpm.Dal;
using Wpm.Domain;

var cb = new ConfigurationBuilder();
cb.AddJsonFile("config.json");
var config = cb.Build();


using var db = new WpmDbContext(config);
//db.Database.EnsureDeleted();
//db.Database.EnsureCreated();

/*
var species = db.Species
    .Where(s => s.Id == 2)
    .ToList();
foreach (var item in species)
{
    Console.WriteLine(item.Name);
}
*/

var breeds = db.Breeds
               .Include(b => b.Species)
               .Select(b => new { BreedName = b.Name, SpeciesName = b.Species.Name })
               .OrderBy(b => b.SpeciesName)
               .ThenBy(b => b.BreedName)
               .ToList();
               

foreach (var item in breeds) 
{
    Console.WriteLine($"{item.BreedName} - {item.SpeciesName}");
}

/*
var pets = db.Pets
             .Include(p => p.Owners)
             .ToList();

Console.WriteLine();
*/