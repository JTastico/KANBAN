using kanban_backend.Domain.Interfaces;
using kanban_backend.Infrastructure.Data.Entities;

namespace kanban_backend.Application.Services
{
    public class PersonaService
    {
        private readonly IPersonaRepository _repository;

        public PersonaService(IPersonaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Persona>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Persona?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Persona> CreateAsync(Persona persona)
        {
            persona.FechaRegistro ??= DateOnly.FromDateTime(DateTime.UtcNow);
            return await _repository.AddAsync(persona);
        }

        public async Task UpdateAsync(Persona persona)
        {
            await _repository.UpdateAsync(persona);
        }

        public async Task DeleteAsync(int id)
        {
            var persona = await _repository.GetByIdAsync(id);
            if (persona != null)
            {
                await _repository.DeleteAsync(persona);
            }
        }
    }
}