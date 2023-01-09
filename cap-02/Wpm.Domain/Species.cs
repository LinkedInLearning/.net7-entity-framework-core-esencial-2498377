namespace Wpm.Domain;
public class Species
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public List<Pet> Pets { get; set; } = new List<Pet>();
}