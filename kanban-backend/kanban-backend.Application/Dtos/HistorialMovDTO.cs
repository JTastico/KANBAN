namespace kanban_backend.Application.Dtos;

public class HistorialMovDTO
{
    public int? IdTarea { get; set; }

    public int? IdColumnaOrigen { get; set; }

    public int? IdColumnaDestino { get; set; }

    public DateTime? FechaMovimiento { get; set; }

    public int? IdUsuario { get; set; }
}