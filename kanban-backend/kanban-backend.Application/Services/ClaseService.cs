

using kanban_backend.Domain.Interfaces;
using kanban_backend.Infrastructure.Data.Entities;

namespace kanban_backend.Application.Services
{
    public class ClaseService
    {
        private readonly IClaseRepository _claseRepository;

        public ClaseService(IClaseRepository claseRepository)
        {
            _claseRepository = claseRepository;
        }

        public async Task<IEnumerable<Clase>> GetAllAsync()
        {
            return await _claseRepository.GetAllAsync();
        }

        public async Task<Clase?> GetByIdAsync(int id)
        {
            return await _claseRepository.GetByIdAsync(id);
        }

        public async Task<Clase> CreateAsync(Clase clase)
        {
            return await _claseRepository.AddAsync(clase);
        }

        public async Task UpdateAsync(Clase clase)
        {
            await _claseRepository.UpdateAsync(clase);
        }

        public async Task DeleteAsync(int id)
        {
            var clase = await _claseRepository.GetByIdAsync(id);
            if (clase != null)
            {
                await _claseRepository.DeleteAsync(clase);
            }
        }
    }
}