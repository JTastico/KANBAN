using kanban_backend.Domain.Interfaces;
using kanban_backend.Infrastructure.Data.Context;
using kanban_backend.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace kanban_backend.Infrastructure.Adapters.Repositories;

public class CarreraRepository : GenericRepository<Carrera>, ICarreraRepository
{
    private ApplicationDbContext context;
    public CarreraRepository(ApplicationDbContext context):base(context)
    {
        this.context = context;
    }

    public async Task<List<Carrera>> searchByName(string name)
    {
        return await context.Carrera.Where(src => src.Nombre == name).ToListAsync();
    }
    
}