namespace Shoniz.Framework.Persistence;

public interface IDbContext : IDisposable
{
    int SaveChanges();
}