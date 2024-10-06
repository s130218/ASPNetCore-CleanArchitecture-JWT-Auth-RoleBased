using IdentityCleanArch.Core.Infrastructure.DataAccess;
using IdentityCleanArch.EntityFrameWork.DbContext;
using Microsoft.EntityFrameworkCore;


namespace IdentityCleanArch.EntityFrameWork.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    #region Ctor & Properties
    private readonly ApplicationDbContext _db;
    public Repository(ApplicationDbContext db)
    {
        _db = db;
    }
    #endregion

    #region Implementation

    public void Add(T entity)
    {
        _db.Set<T>().Add(entity);
    }
    public async Task<T> GetByIdAsync(int id)
    {
        return await _db.Set<T>().FindAsync(id).ConfigureAwait(false);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _db.Set<T>().ToListAsync().ConfigureAwait(false);
    }

    public void Update(T entity)
    {
        _db.Entry(entity).State = EntityState.Modified;
    }

    public void Remove(T entity)
    {
        _db.Set<T>().Remove(entity);
    }

    public void SaveChanges()
    {
        _db.SaveChanges();
    }

    public virtual IQueryable<T> Table
    {
        get
        {
            return _db.Set<T>();
        }
    }

    public virtual IQueryable<T> TableNoTracking
    {
        get
        {
            return _db.Set<T>().AsNoTracking();
        }
    }
    #endregion
}
