using Shoniz.Framework.ACL;

namespace Shoniz.CostAccounting.FormulationContext.Facade.Contracts.ACL.WarehouseContext
{
    public interface IWarehouseAclService : IAclService
    {
        bool IsGoodsCodeValid(Guid id);
    }
}
