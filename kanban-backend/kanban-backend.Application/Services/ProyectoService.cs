using System.Runtime.InteropServices.JavaScript;
using kanban_backend.Application.Dtos;
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

        public async Task<Proyecto> CreateAsync(ProyectoDTO dto)
        {
            var data = new Proyecto();
            data.Descripcion = dto.Descripcion;
            data.Nombre = dto.Nombre;
            data.FechaFin = dto.FechaFin;
            data.FechaInicio = dto.FechaInicio ?? DateTime.Now;
            data.IdLider = dto.IdLider;
            
            var response = await _repository.AddAsync(data);
            //aqui armas el dto que necesita el proximo servicio
            //llamas al proximo servicio -> serviceSiguiente.Agreegar(dtoNuevo);
            
            
            //aqui creo el primero
            //aqui llamas al segundo

            return response;
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