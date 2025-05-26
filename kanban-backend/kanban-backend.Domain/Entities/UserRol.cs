using System;
using System.Collections.Generic;

namespace kanban_backend.Infrastructure.Data.Entities;

public partial class UserRol
{
    public int Id { get; set; }

    public int? IdUser { get; set; }

    public int? IdRol { get; set; }

    public int? IdProyecto { get; set; }

    public int? IdGrupo { get; set; }

    public DateTime? FechaAsignacion { get; set; }

    public virtual Grupo? IdGrupoNavigation { get; set; }

    public virtual Proyecto? IdProyectoNavigation { get; set; }

    public virtual Rol? IdRolNavigation { get; set; }

    public virtual Usuario? IdUserNavigation { get; set; }
}
