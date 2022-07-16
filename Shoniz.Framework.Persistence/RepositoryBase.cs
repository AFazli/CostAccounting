using Microsoft.EntityFrameworkCore;
using Shoniz.Framework.Core.Domain;
using Shoniz.Framework.Domain;
using System.Linq.Expressions;

namespace Shoniz.Framework.Persistence
{
    public abstract class RepositoryBase<TAggregateRoot>
        where TAggregateRoot : EntityBase, IAggregateRoot<TAggregateRoot>, new()
    {
        private readonly DbContextBase _context;

        protected RepositoryBase(IDbContext context)
        {
            _context = context as DbContextBase;
        }

        protected IQueryable<TAggregateRoot> GetAll()
        {
            var set = _context.Set<TAggregateRoot>().AsQueryable();
            var includedExpressions = new TAggregateRoot().GetAggregateExpressions();

            if (includedExpressions == null)
            {
                return set;
            }

            return includedExpressions.Aggregate(set, (current, expression) => current.Include(expression));
        }

        public void Add(TAggregateRoot entity)
        {
            _context.Set<TAggregateRoot>().Add(entity);
        }

        public void Delete(TAggregateRoot entity)
        {
            _context.Set<TAggregateRoot>().Remove(entity);
        }

        public TAggregateRoot Get(Guid id)
        {
            return this.GetAll().Single(e => e.Id == id);
        }

        public bool Exist(Expression<Func<TAggregateRoot, bool>> predicate)
        {
            return GetAll().Any(predicate);
        }
    }
}
