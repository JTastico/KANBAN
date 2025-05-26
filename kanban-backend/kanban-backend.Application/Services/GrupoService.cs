using kanban_backend.Application.Dtos;
using kanban_backend.Domain.Interfaces;
using kanban_backend.Infrastructure.Data.Entities;

namespace kanban_backend.Application.Services
{
    public class GrupoService
    {
        private readonly IGrupoRepository _repository;

        public GrupoService(IGrupoRepository grupoRepository)
        {
            _repository = grupoRepository;
        }

        public async Task<IEnumerable<Grupo>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Grupo?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Grupo> CreateAsync(GrupoDTO dto)
        {
            var data = new Grupo();
            data.Nombre = dto.Nombre;
            data.IdClase = dto.IdClase;
            
            var response = await _repository.AddAsync(data);
            return response;
        }

        public async Task UpdateAsync(Grupo grupo)
        {
            await _repository.UpdateAsync(grupo);
        }

        public async Task DeleteAsync(int id)
        {
            var grupo = await _repository.GetByIdAsync(id);
            if (grupo != null)
            {
                await _repository.DeleteAsync(grupo);
            }
        }
    }
}