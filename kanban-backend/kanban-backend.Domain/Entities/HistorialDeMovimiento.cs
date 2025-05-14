using System;
using System.Collections.Generic;

namespace kanban_backend.Infrastructure.Data.Entities;

public partial class HistorialDeMovimiento
{
    public int Id { get; set; }

    public int? IdTarea { get; set; }

    public int? IdColumnaOrigen { get; set; }

    public int? IdColumnaDestino { get; set; }

    public DateTime? FechaMovimiento { get; set; }

    public int? IdUsuario { get; set; }

    public virtual Tareas? IdTareaNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
