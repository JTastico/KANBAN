using kanban_backend.Application.Dtos;
using kanban_backend.Domain.Interfaces;
using kanban_backend.Infrastructure.Data.Entities;

namespace kanban_backend.Application.Services
{
    public class UserRolService
    {
        private readonly IUserRolRepository _repository;

        public UserRolService(IUserRolRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<UserRol>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<UserRol?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<UserRol> CreateAsync(UserRolDTO dto)
        {
            var data = new UserRol();
            data.IdUser = dto.IdUser;
            data.IdRol = dto.IdRol;
            data.IdProyecto = dto.IdProyecto;
            data.IdGrupo = dto.IdGrupo;
            data.FechaAsignacion = dto.FechaAsignacion;
            
            var response = await _repository.AddAsync(data);
            return response;
        }

        public async Task UpdateAsync(UserRol userRol)
        {
            await _repository.UpdateAsync(userRol);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity != null)
            {
                await _repository.DeleteAsync(entity);
            }
        }
    }
}