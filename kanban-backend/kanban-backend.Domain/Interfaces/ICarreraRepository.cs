using kanban_backend.Infrastructure.Data.Entities;

namespace kanban_backend.Domain.Interfaces;

public interface ICarreraRepository : IGenericRepository<Carrera>
{
    Task<List<Carrera>> searchByName(string name);
}