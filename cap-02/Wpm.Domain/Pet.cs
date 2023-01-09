namespace Wpm.Domain;
public class Pet
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int? Age { get; set; }
    public decimal? Weight { get; set; }

    public int SpeciesId { get; set; }
}
