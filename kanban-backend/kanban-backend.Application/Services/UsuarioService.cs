using kanban_backend.Application.Dtos;
using kanban_backend.Domain.Interfaces;
using kanban_backend.Infrastructure.Data.Entities;

namespace kanban_backend.Application.Services
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Usuario> CreateAsync(UsuarioDTO dto)
        {
            var data = new Usuario();
            data.Username = dto.Username;
            data.CorreoInstitucional = dto.CorreoInstitucional;
            data.Contraseña = dto.Contraseña;
            data.UltimoIngreso = dto.UltimoIngreso;
            data.IdPersona = dto.IdPersona;

            var response = await _repository.AddAsync(data);
            return response;
        }

        public async Task UpdateAsync(Usuario usuario)
        {
            await _repository.UpdateAsync(usuario);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity != null)
            {
                await _repository.DeleteAsync(entity);
            }
        }
    }
}