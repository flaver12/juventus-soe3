using System;
using System.Collections.Generic;

namespace linq.Model;

public partial class Abteilung
{
    public int AbteilungId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Mitarbeiter> Mitarbeiters { get; set; } = new List<Mitarbeiter>();
}
