namespace Wpm.Domain;
public class Breed
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public List<Pet> Pets { get; set; } = new List<Pet>();
}
