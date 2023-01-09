using System;
using System.Collections.Generic;

namespace EjemploScaffolding;

public partial class Species
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Pet> Pets { get; } = new List<Pet>();
}
