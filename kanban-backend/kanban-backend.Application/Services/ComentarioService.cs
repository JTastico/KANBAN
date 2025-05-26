using kanban_backend.Application.Dtos;
using kanban_backend.Domain.Interfaces;
using kanban_backend.Infrastructure.Data.Entities;

namespace kanban_backend.Application.Services
{
    public class ComentarioService
    {
        private readonly IComentarioRepository _repository;

        public ComentarioService(IComentarioRepository comentarioRepository)
        {
            _repository = comentarioRepository;
        }

        public async Task<IEnumerable<Comentario>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Comentario?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Comentario> CreateAsync(ComentarioDTO dto)
        {
            var data = new Comentario();
            data.Contenido = dto.Contenido;
            data.Fecha = dto.Fecha;
            data.IdTarea = dto.IdTarea;
            data.IdUsuario = dto.IdUsuario;
            
            var response = await _repository.AddAsync(data);
            return response;
        }

        public async Task UpdateAsync(Comentario comentario)
        {
            await _repository.UpdateAsync(comentario);
        }

        public async Task DeleteAsync(int id)
        {
            var comentario = await _repository.GetByIdAsync(id);
            if (comentario != null)
            {
                await _repository.DeleteAsync(comentario);
            }
        }
    }
}