

using kanban_backend.Application.Dtos;
using kanban_backend.Domain.Interfaces;
using kanban_backend.Infrastructure.Data.Entities;

namespace kanban_backend.Application.Services
{
    public class ClaseService
    {
        private readonly IClaseRepository _repository;

        public ClaseService(IClaseRepository claseRepository)
        {
            _repository = claseRepository;
        }

        public async Task<IEnumerable<Clase>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Clase?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Clase> CreateAsync(ClaseDTO dto)
        {
            var data = new Clase();
            data.Clase1 = dto.Clase1;
            data.IdCarrera = dto.IdCarrera;
            
            var response = await _repository.AddAsync(data); // Fixed typo
            return response;
        }

        public async Task UpdateAsync(Clase clase)
        {
            await _repository.UpdateAsync(clase);
        }

        public async Task DeleteAsync(int id)
        {
            var clase = await _repository.GetByIdAsync(id);
            if (clase != null)
            {
                await _repository.DeleteAsync(clase);
            }
        }
    }
}