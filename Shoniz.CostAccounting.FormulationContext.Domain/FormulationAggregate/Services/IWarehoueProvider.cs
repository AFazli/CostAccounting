using Shoniz.Framework.Domain;

namespace Shoniz.CostAccounting.FormulationContext.Domain.FormulationAggregate.Services
{
    public interface IWarehoueProvider : IDomainService
    {
        bool IsGoodsCodeValid(Guid id);
    }
}
