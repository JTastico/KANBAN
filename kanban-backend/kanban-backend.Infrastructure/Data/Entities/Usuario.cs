using System;
using System.Collections.Generic;

namespace kanban_backend.Infrastructure.Data.Entities;

public partial class Usuario
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? CorreoInstitucional { get; set; }

    public string? Contraseña { get; set; }

    public DateTime? UltimoIngreso { get; set; }

    public int? IdPersona { get; set; }

    public virtual ICollection<Comentario> Comentario { get; set; } = new List<Comentario>();

    public virtual ICollection<HistorialDeMovimiento> HistorialDeMovimiento { get; set; } = new List<HistorialDeMovimiento>();

    public virtual Persona? IdPersonaNavigation { get; set; }

    public virtual ICollection<Proyecto> Proyecto { get; set; } = new List<Proyecto>();

    public virtual ICollection<Tareas> Tareas { get; set; } = new List<Tareas>();

    public virtual ICollection<UserRol> UserRol { get; set; } = new List<UserRol>();
}
