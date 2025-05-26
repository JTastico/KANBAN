using kanban_backend.Application.Dtos;
using kanban_backend.Domain.Interfaces;
using kanban_backend.Infrastructure.Data.Entities;

namespace kanban_backend.Application.Services
{
    public class HistorialMovService
    {
        private readonly IHistorialMovRepository _repository;

        public HistorialMovService(IHistorialMovRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<HistorialDeMovimiento>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<HistorialDeMovimiento?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<HistorialDeMovimiento> CreateAsync(HistorialMovDTO dto)
        {
            var data = new HistorialDeMovimiento();
            data.IdTarea = dto.IdTarea;
            data.IdColumnaOrigen = dto.IdColumnaOrigen;
            data.IdColumnaDestino = dto.IdColumnaDestino;
            data.FechaMovimiento = dto.FechaMovimiento;
            data.IdUsuario = dto.IdUsuario;
            
            var response = await _repository.AddAsync(data);
            return response;
        }

        public async Task UpdateAsync(HistorialDeMovimiento historial)
        {
            await _repository.UpdateAsync(historial);
        }

        public async Task DeleteAsync(int id)
        {
            var historial = await _repository.GetByIdAsync(id);
            if (historial != null)
            {
                await _repository.DeleteAsync(historial);
            }
        }
    }
}