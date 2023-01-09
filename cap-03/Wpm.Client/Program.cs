using Microsoft.Extensions.Configuration;
using Wpm.Dal;
using Wpm.Domain;


var cb = new ConfigurationBuilder();
cb.AddJsonFile("config.json");
var config = cb.Build();


using var db = new WpmDbContext(config);
//db.Database.EnsureCreated();

var allPets = db.Pets.ToList();
Console.WriteLine(allPets.Count);

var cat = new Species() { Name = "Gato" };
cat.Pets.Add(new Pet() { Name = "Garfield", Weight = 40 });

var dog = new Species() { Name = "Perro" };

db.Species.Add(cat);
db.Species.Add(dog);

db.SaveChanges();