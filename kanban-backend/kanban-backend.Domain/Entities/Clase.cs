using System;
using System.Collections.Generic;

namespace kanban_backend.Infrastructure.Data.Entities;

public partial class Clase
{
    public int Id { get; set; }

    public string? Clase1 { get; set; }

    public int? IdCarrera { get; set; }

    public virtual ICollection<Grupo> Grupo { get; set; } = new List<Grupo>();

    public virtual Carrera? IdCarreraNavigation { get; set; }
}
