using Shoniz.Framework.Core.Domain;

namespace Shoniz.Framework.Core.Persistence;

public interface IRepository<TAggregateRoot> where TAggregateRoot : IAggregateRoot<TAggregateRoot>
{

}