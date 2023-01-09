using System;
using System.Collections.Generic;

namespace EjemploScaffolding;

public partial class Pet
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? Age { get; set; }

    public decimal? Weight { get; set; }

    public int SpeciesId { get; set; }

    public int BreedId { get; set; }

    public virtual Breed Breed { get; set; } = null!;

    public virtual Species Species { get; set; } = null!;
}
