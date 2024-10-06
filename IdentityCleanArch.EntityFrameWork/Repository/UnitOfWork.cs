using IdentityCleanArch.Core.Infrastructure.DataAccess;
using IdentityCleanArch.EntityFrameWork.DbContext;

namespace IdentityCleanArch.EntityFrameWork.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _db;
    public UnitOfWork(ApplicationDbContext db)
    {
        _db = db;
    }

    public void CommitChanges()
    {
        _db.SaveChanges();
    }

    public async Task CommitAsync()
    {
        await _db.SaveChangesAsync();
    }

    public void Dispose()
    {
        _db.Dispose();
    }
}
