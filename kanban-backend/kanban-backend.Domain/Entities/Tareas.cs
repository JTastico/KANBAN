using System;
using System.Collections.Generic;

namespace kanban_backend.Infrastructure.Data.Entities;

public partial class Tareas
{
    public int Id { get; set; }

    public string? Titulo { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaEntrega { get; set; }

    public int? IdEstado { get; set; }

    public int? IdProyecto { get; set; }

    public int? IdAsignado { get; set; }

    public string? Prioridad { get; set; }

    public virtual ICollection<Comentario> Comentario { get; set; } = new List<Comentario>();

    public virtual ICollection<HistorialDeMovimiento> HistorialDeMovimiento { get; set; } = new List<HistorialDeMovimiento>();

    public virtual Usuario? IdAsignadoNavigation { get; set; }

    public virtual Proyecto? IdProyectoNavigation { get; set; }
}
