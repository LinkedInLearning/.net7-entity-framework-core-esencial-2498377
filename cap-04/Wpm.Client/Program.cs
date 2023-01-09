using Microsoft.Extensions.Configuration;
using Wpm.Dal;
using Wpm.Domain;

var cb = new ConfigurationBuilder();
cb.AddJsonFile("config.json");
var config = cb.Build();


using var db = new WpmDbContext(config);
db.Database.EnsureDeleted();
db.Database.EnsureCreated();

var perro = new Species() { Name = "Perro" };
var gato = new Species() { Name = "Gato" };

db.Species.Add(perro);
db.Species.Add(gato);

db.SaveChanges();

Console.WriteLine("Listo");

var beagle = new Breed() { Name = "Beagle", Species = perro };

db.Breeds.Add(beagle);

db.SaveChanges();

Console.WriteLine("Se agregó una raza");

var pitbull = new Breed() { Name = "Pitbull", SpeciesId = 1 };
var siames = new Breed() { Name = "Siamés", SpeciesId = 2 };

db.Breeds.Add(pitbull);
db.Breeds.Add(siames);

db.SaveChanges();

Console.WriteLine("Se agregaron razas usando los identificadores");

var gianni = new Pet() { Name = "Gianni", Breed = beagle };
var cati = new Pet() { Name = "Cati", BreedId = 2 };

db.Pets.Add(gianni);
db.Pets.Add(cati);

db.SaveChanges();

Console.WriteLine("Se agregaron dos mascotas");

var rodrigo = new Owner() { Name = "Rodrigo" };
var leonardo = new Owner() { Name = "Leonardo" };
gianni.Owners.Add(rodrigo);
gianni.Owners.Add(leonardo);
cati.Owners.Add(rodrigo);
cati.Owners.Add(leonardo);

db.SaveChanges();

Console.WriteLine("Se agregaron los dueños");

gianni.Age = 10;
gianni.Weight = 19.5m;
cati.Age = 8;
cati.Weight = 33.5m;

db.SaveChanges();

Console.WriteLine("Se han modificado los datos de edad y peso");