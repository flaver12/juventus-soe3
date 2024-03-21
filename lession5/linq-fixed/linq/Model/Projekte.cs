using System;
using System.Collections.Generic;

namespace linq.Model;

public partial class Projekte
{
    public int ProjekteId { get; set; }

    public string? ProjektName { get; set; }

    public virtual ICollection<Mitarbeiter> Mitarbeiters { get; set; } = new List<Mitarbeiter>();
}
