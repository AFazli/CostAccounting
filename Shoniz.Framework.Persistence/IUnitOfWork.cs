namespace Shoniz.Framework.Persistence
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
    }
}
