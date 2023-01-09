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
var pets = db.Pets.FromSqlRaw("SELECT * FROM Pets WHERE Age > 20").ToList();
foreach (var item in pets)
{
    Console.WriteLine(item.Name);
}
*/

//var pets = db.Pets.FromSqlInterpolated($"SELECT * FROM Pets WHERE Age >= {20}").ToList();
//foreach (var item in pets)
//{
//    Console.WriteLine(item.Name);
//}


//var pets = db.Pets.FromSqlRaw("GetOverweightPets").ToList();
//foreach (var item in pets)
//{
//    Console.WriteLine(item.Name);
//}

/*var rows = db.Database.ExecuteSqlInterpolated($"DeleteOwner {7}");
Console.WriteLine(rows);*/

var allPets = db.AllPets.ToList();
foreach (var item in allPets)
{
    Console.WriteLine($"{item.Name} - {item.SpeciesName} / {item.BreedName}");
    Console.WriteLine($"Edad: {item.Age}");
    Console.WriteLine($"¿Con sobrepeso? {(item.IsOverweight ? "Sí" : "No")}");
    Console.WriteLine($"Total de dueños: {item.TotalOwners}");
    Console.WriteLine();
}
