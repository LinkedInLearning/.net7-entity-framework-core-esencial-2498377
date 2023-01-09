namespace Wpm.Domain;
public class Breed
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public Species Species { get; set; }
    public int SpeciesId { get; set; }
}