namespace kanban_backend.Application.Dtos;

public class TareasDTO
{
    public string? Titulo { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaEntrega { get; set; }

    public int? IdEstado { get; set; }

    public int? IdProyecto { get; set; }

    public int? IdAsignado { get; set; }

    public string? Prioridad { get; set; }
}