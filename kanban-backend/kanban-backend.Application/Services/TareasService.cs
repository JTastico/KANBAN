using kanban_backend.Application.Dtos;
using kanban_backend.Domain.Interfaces;
using kanban_backend.Infrastructure.Data.Entities;

namespace kanban_backend.Application.Services
{
    public class TareasService
    {
        private readonly ITareasRepository _repository;

        public TareasService(ITareasRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Tareas>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Tareas?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Tareas> CreateAsync(TareasDTO dto)
        {
            var data = new Tareas();
            data.Titulo = dto.Titulo;
            data.Descripcion = dto.Descripcion;
            data.FechaCreacion = dto.FechaCreacion;
            data.FechaEntrega = dto.FechaEntrega;
            data.IdEstado = dto.IdEstado;
            data.IdProyecto = dto.IdProyecto;
            data.IdAsignado = dto.IdAsignado;
            data.Prioridad = dto.Prioridad;
            
            var response = await _repository.AddAsync(data);
            return response;
        }

        public async Task UpdateAsync(Tareas tarea)
        {
            await _repository.UpdateAsync(tarea);
        }

        public async Task DeleteAsync(int id)
        {
            var tarea = await _repository.GetByIdAsync(id);
            if (tarea != null)
            {
                await _repository.DeleteAsync(tarea);
            }
        }
    }
}