using System;
using System.Collections.Generic;

namespace kanban_backend.Infrastructure.Data.Entities;

public partial class Carrera
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Codigo { get; set; }

    public virtual ICollection<Clase> Clase { get; set; } = new List<Clase>();
}
