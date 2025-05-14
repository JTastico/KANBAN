using System;
using System.Collections.Generic;

namespace kanban_backend.Infrastructure.Data.Entities;

public partial class Grupo
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public int? IdClase { get; set; }

    public virtual Clase? IdClaseNavigation { get; set; }

    public virtual ICollection<UserRol> UserRol { get; set; } = new List<UserRol>();
}
