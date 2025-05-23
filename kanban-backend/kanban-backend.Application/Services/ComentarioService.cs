using kanban_backend.Domain.Interfaces;
using kanban_backend.Infrastructure.Data.Entities;

namespace kanban_backend.Application.Services
{
    public class ComentarioService
    {
        private readonly IComentarioRepository _comentarioRepository;

        public ComentarioService(IComentarioRepository comentarioRepository)
        {
            _comentarioRepository = comentarioRepository;
        }

        public async Task<IEnumerable<Comentario>> GetAllAsync()
        {
            return await _comentarioRepository.GetAllAsync();
        }

        public async Task<Comentario?> GetByIdAsync(int id)
        {
            return await _comentarioRepository.GetByIdAsync(id);
        }

        public async Task<Comentario> CreateAsync(Comentario comentario)
        {
            return await _comentarioRepository.AddAsync(comentario);
        }

        public async Task UpdateAsync(Comentario comentario)
        {
            await _comentarioRepository.UpdateAsync(comentario);
        }

        public async Task DeleteAsync(int id)
        {
            var comentario = await _comentarioRepository.GetByIdAsync(id);
            if (comentario != null)
            {
                await _comentarioRepository.DeleteAsync(comentario);
            }
        }
    }
}