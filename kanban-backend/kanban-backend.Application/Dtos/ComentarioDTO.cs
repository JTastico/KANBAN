namespace kanban_backend.Application.Dtos;

public class ComentarioDTO
{
    public string? Contenido { get; set; }

    public DateTime? Fecha { get; set; }

    public int? IdTarea { get; set; }

    public int? IdUsuario { get; set; }

}