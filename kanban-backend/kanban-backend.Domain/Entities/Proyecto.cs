
namespace kanban_backend.Infrastructure.Data.Entities;

public partial class Proyecto
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public int? IdLider { get; set; }

    public virtual Usuario? IdLiderNavigation { get; set; }

    public virtual ICollection<Tareas> Tareas { get; set; } = new List<Tareas>();

    public virtual ICollection<UserRol> UserRol { get; set; } = new List<UserRol>();
}