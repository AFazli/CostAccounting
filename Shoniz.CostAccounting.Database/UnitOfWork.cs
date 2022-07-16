using Microsoft.EntityFrameworkCore;
using Shoniz.Framework.Persistence;

namespace Shoniz.CostAccounting.Database
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext _context;
        private readonly DbContextBase _dbContextBase;

        public UnitOfWork(IDbContext context)
        {
            _context = context;
            _dbContextBase = _context as DbContextBase;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            _dbContextBase.ChangeTracker
                .Entries()
                .Where(e => e.Entity != null)
                .ToList()
                .ForEach(e => e.State = EntityState.Detached);

            //_context.Dispose(); //todo: better design
        }
    }
}
