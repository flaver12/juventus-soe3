using System;
using System.Collections.Generic;

namespace linq.Model;

public partial class Mitarbeiter
{
    public int MitarbeiterId { get; set; }

    public string? Name { get; set; }

    public string? Vorname { get; set; }

    public string? Position { get; set; }

    public int ProjektId { get; set; }

    public int AbteilungId { get; set; }

    public virtual Abteilung Abteilung { get; set; } = null!;

    public virtual Projekte Projekt { get; set; } = null!;
}
