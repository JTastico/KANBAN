using kanban_backend.Domain.Interfaces;
using kanban_backend.Infrastructure.Data.Context;
using kanban_backend.Infrastructure.Data.Entities;

namespace kanban_backend.Infrastructure.Adapters.Repositories;

public class GrupoRepository: GenericRepository<Grupo>, IGrupoRepository
{
    private ApplicationDbContext context;

    public GrupoRepository(ApplicationDbContext context) : base(context)
    {
        this.context = context;
    }
}