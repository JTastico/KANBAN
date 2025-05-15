using kanban_backend.Domain.Interfaces;
using kanban_backend.Infrastructure.Data.Context;
using kanban_backend.Infrastructure.Data.Entities;

namespace kanban_backend.Infrastructure.Adapters.Repositories;

public class TareasRepository: GenericRepository<Tareas>, ITareasRepository
{
    private ApplicationDbContext context;

    public TareasRepository(ApplicationDbContext context) : base(context)
    {
        this.context = context;
    }
}