using kanban_backend.Domain.Interfaces;
using kanban_backend.Infrastructure.Data.Context;
using kanban_backend.Infrastructure.Data.Entities;

namespace kanban_backend.Infrastructure.Adapters.Repositories;

public class RolRepository: GenericRepository<Rol>, IRolRepository
{
    private ApplicationDbContext context;

    public RolRepository(ApplicationDbContext context) : base(context)
    {
        this.context = context;
    }
    
}