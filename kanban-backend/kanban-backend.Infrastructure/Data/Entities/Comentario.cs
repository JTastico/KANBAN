using System;
using System.Collections.Generic;

namespace kanban_backend.Infrastructure.Data.Entities;

public partial class Comentario
{
    public int Id { get; set; }

    public string? Contenido { get; set; }

    public DateTime? Fecha { get; set; }

    public int? IdTarea { get; set; }

    public int? IdUsuario { get; set; }

    public virtual Tareas? IdTareaNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
