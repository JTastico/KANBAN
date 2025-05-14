using kanban_backend.Domain.Interfaces;
using kanban_backend.Infrastructure.Data.Context;
using kanban_backend.Infrastructure.Data.Entities;

namespace kanban_backend.Infrastructure.Adapters.Repositories;

public class ComentarioRepository : GenericRepository<Comentario>, IComentarioRepository
{
    private ApplicationDbContext context;

    public ComentarioRepository(ApplicationDbContext context):base(context)
    {
        this.context = context;
    }
}