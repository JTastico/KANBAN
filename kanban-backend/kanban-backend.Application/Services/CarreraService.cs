using kanban_backend.Domain.Interfaces;
using kanban_backend.Infrastructure.Data.Entities;

namespace kanban_backend.Application.Services
{
    public class CarreraService
    {
        private readonly ICarreraRepository _repository;

        public CarreraService(ICarreraRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Carrera>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Carrera?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Carrera> CreateAsync(Carrera carrera)
        {
            return await _repository.AddAsync(carrera);
        }

        public async Task UpdateAsync(Carrera carrera)
        {
            await _repository.UpdateAsync(carrera);
        }

        public async Task DeleteAsync(int id)
        {
            var carrera = await _repository.GetByIdAsync(id);
            if (carrera != null)
            {
                await _repository.DeleteAsync(carrera);
            }
        }

        public async Task<List<Carrera>> SearchByNameAsync(string name)
        {
            return await _repository.searchByName(name);
        }
    }
}