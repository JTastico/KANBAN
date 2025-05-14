using System;
using System.Collections.Generic;

namespace kanban_backend.Infrastructure.Data.Entities;

public partial class Rol
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public bool? Estatus { get; set; }

    public virtual ICollection<UserRol> UserRol { get; set; } = new List<UserRol>();
}
