using kanban_backend.Domain.Interfaces;
using kanban_backend.Infrastructure.Data.Context;
using kanban_backend.Infrastructure.Data.Entities;

namespace kanban_backend.Infrastructure.Adapters.Repositories;

public class UsuarioRepository: GenericRepository<Usuario>, IUsuarioRepository
{
    private ApplicationDbContext context;

    public UsuarioRepository(ApplicationDbContext context) : base(context)
    {
        this.context = context;
    }
}