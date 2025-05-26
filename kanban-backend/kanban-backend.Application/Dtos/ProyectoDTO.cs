namespace kanban_backend.Application.Dtos;

public class ProyectoDTO
{
    

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public int? IdLider { get; set; }
}


