using kanban_backend.Domain.Interfaces;
using kanban_backend.Infrastructure.Data.Context;
using kanban_backend.Infrastructure.Data.Entities;

namespace kanban_backend.Infrastructure.Adapters.Repositories;

public class HistorialMovRepository: GenericRepository<HistorialDeMovimiento>, IHistorialMovRepository
{
    private ApplicationDbContext context;
    public HistorialMovRepository(ApplicationDbContext context) : base(context)
    {
        this.context = context;
    }
}