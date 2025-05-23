using kanban_backend.Domain.Interfaces;
using kanban_backend.Infrastructure.Data.Entities;

namespace kanban_backend.Application.Services
{
    public class GrupoService
    {
        private readonly IGrupoRepository _grupoRepository;

        public GrupoService(IGrupoRepository grupoRepository)
        {
            _grupoRepository = grupoRepository;
        }

        public async Task<IEnumerable<Grupo>> GetAllAsync()
        {
            return await _grupoRepository.GetAllAsync();
        }

        public async Task<Grupo?> GetByIdAsync(int id)
        {
            return await _grupoRepository.GetByIdAsync(id);
        }

        public async Task<Grupo> CreateAsync(Grupo grupo)
        {
            return await _grupoRepository.AddAsync(grupo);
        }

        public async Task UpdateAsync(Grupo grupo)
        {
            await _grupoRepository.UpdateAsync(grupo);
        }

        public async Task DeleteAsync(int id)
        {
            var grupo = await _grupoRepository.GetByIdAsync(id);
            if (grupo != null)
            {
                await _grupoRepository.DeleteAsync(grupo);
            }
        }
    }
}