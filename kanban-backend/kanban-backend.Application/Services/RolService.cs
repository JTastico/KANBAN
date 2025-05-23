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

        public async Task<Rol> CreateAsync(Rol rol)
        {
            rol.Estatus ??= true; // Asignar estatus activo por defecto si no se define
            return await _repository.AddAsync(rol);
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