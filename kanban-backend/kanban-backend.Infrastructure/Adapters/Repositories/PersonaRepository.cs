using kanban_backend.Domain.Interfaces;
using kanban_backend.Infrastructure.Data.Context;
using kanban_backend.Infrastructure.Data.Entities;

namespace kanban_backend.Infrastructure.Adapters.Repositories;

public class PersonaRepository: GenericRepository<Persona>, IPersonaRepository
{
    private ApplicationDbContext context;

    public PersonaRepository(ApplicationDbContext context) : base(context)
    {
        this.context = context;
    }
}