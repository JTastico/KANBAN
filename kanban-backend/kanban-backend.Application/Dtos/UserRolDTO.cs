namespace kanban_backend.Application.Dtos;

public class UserRolDTO
{
    public int? IdUser { get; set; }

    public int? IdRol { get; set; }

    public int? IdProyecto { get; set; }

    public int? IdGrupo { get; set; }

    public DateTime? FechaAsignacion { get; set; }
}