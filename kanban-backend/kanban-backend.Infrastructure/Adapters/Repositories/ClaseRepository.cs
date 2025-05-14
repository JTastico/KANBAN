using kanban_backend.Domain.Interfaces;
using kanban_backend.Infrastructure.Data.Context;
using kanban_backend.Infrastructure.Data.Entities;
namespace kanban_backend.Infrastructure.Adapters.Repositories;

public class ClaseRepository: GenericRepository<Clase>, IClaseRepository
{
    private ApplicationDbContext context;
    public ClaseRepository(ApplicationDbContext context):base(context)
    {
        this.context = context;
    }
}