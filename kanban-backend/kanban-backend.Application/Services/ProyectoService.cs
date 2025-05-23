using kanban_backend.Domain.Interfaces;
using kanban_backend.Infrastructure.Data.Entities;

namespace kanban_backend.Application.Services
{
    public class ProyectoService
    {
        private readonly IProyectoRepository _repository;

        public ProyectoService(IProyectoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Proyecto>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Proyecto?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Proyecto> CreateAsync(Proyecto proyecto)
        {
            proyecto.FechaInicio ??= DateOnly.FromDateTime(DateTime.UtcNow);
            return await _repository.AddAsync(proyecto);
        }

        public async Task UpdateAsync(Proyecto proyecto)
        {
            await _repository.UpdateAsync(proyecto);
        }

        public async Task DeleteAsync(int id)
        {
            var proyecto = await _repository.GetByIdAsync(id);
            if (proyecto != null)
            {
                await _repository.DeleteAsync(proyecto);
            }
        }
    }
}