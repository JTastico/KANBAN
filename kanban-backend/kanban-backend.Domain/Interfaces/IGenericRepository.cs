namespace kanban_backend.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByAsync(int id);
        Task<T> AddAsync(T entity);
        Task<bool> AddRangeAsync(List<T> entities);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}