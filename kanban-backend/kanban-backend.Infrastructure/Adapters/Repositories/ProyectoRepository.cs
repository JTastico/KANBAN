using kanban_backend.Domain.Interfaces;
using kanban_backend.Infrastructure.Data.Context;
using kanban_backend.Infrastructure.Data.Entities;

namespace kanban_backend.Infrastructure.Adapters.Repositories;

public class ProyectoRepository: GenericRepository<Proyecto>, IProyectoRepository
{
    private ApplicationDbContext context;

    public ProyectoRepository(ApplicationDbContext context) : base(context)
    {
        this.context = context;
    }
}


