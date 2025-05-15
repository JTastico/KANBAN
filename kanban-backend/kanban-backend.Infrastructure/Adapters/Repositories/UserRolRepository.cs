using kanban_backend.Domain.Interfaces;
using kanban_backend.Infrastructure.Data.Context;
using kanban_backend.Infrastructure.Data.Entities;

namespace kanban_backend.Infrastructure.Adapters.Repositories;

public class UserRolRepository: GenericRepository<UserRol>, IUserRolRepository
{
    private ApplicationDbContext context;

    public UserRolRepository(ApplicationDbContext context) : base(context)
    {
        this.context = context;
    }
    
}