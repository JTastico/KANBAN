using kanban_backend.Application.Dtos;
using kanban_backend.Domain.Interfaces;
using kanban_backend.Infrastructure.Data.Entities;

namespace kanban_backend.Application.Services
{
    public class RolService
    {
        private readonly IRolRepository _repository;

        public RolService(IRolRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Rol>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Rol?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Rol> CreateAsync(RollDTO dto)
        {
            var data = new Rol();
            data.Nombre = dto.Nombre;
            data.Descripcion = dto.Descripcion;
            data.Estatus = dto.Estatus;
            
            var response = await _repository.AddAsync(data);
            return response;
        }

        public async Task UpdateAsync(Rol rol)
        {
            await _repository.UpdateAsync(rol);
        }

        public async Task DeleteAsync(int id)
        {
            var rol = await _repository.GetByIdAsync(id);
            if (rol != null)
            {
                await _repository.DeleteAsync(rol);
            }
        }
    }
}