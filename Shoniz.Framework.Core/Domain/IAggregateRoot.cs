using System.Linq.Expressions;

namespace Shoniz.Framework.Core.Domain;

public interface IAggregateRoot<TAggregateRoot>
{
    IEnumerable<Expression<Func<TAggregateRoot, object>>> GetAggregateExpressions();
}