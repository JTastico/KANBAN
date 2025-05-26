namespace kanban_backend.Application.Dtos;

public class UsuarioDTO
{
    public string? Username { get; set; }

    public string? CorreoInstitucional { get; set; }

    public string? Contraseña { get; set; }

    public DateTime? UltimoIngreso { get; set; }

    public int? IdPersona { get; set; }

}