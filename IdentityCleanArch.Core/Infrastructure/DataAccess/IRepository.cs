namespace IdentityCleanArch.Core.Infrastructure.DataAccess;

public interface IRepository<T> where T : class
{
    void Add(T entity);
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    void Remove(T entity);
    void Update(T entity);
    void SaveChanges();
    IQueryable<T> Table { get; }
    IQueryable<T> TableNoTracking { get; }
}
