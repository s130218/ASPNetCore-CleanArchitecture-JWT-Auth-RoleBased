namespace IdentityCleanArch.Core.Infrastructure.DataAccess;

public interface IUnitOfWork : IDisposable
{
    void CommitChanges();

    Task CommitAsync();
}
