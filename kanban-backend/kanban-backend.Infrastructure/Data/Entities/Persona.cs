using System;
using System.Collections.Generic;

namespace kanban_backend.Infrastructure.Data.Entities;

public partial class Persona
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Dni { get; set; }

    public string? Genero { get; set; }

    public string? Telefono { get; set; }

    public string? Direccion { get; set; }

    public string? CorreoPersonal { get; set; }

    public DateOnly? FechaRegistro { get; set; }

    public virtual ICollection<Usuario> Usuario { get; set; } = new List<Usuario>();
}
