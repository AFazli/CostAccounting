using Shoniz.CostAccounting.FormulationContext.Domain.FormulationAggregate.Services;
using Shoniz.CostAccounting.FormulationContext.Facade.Contracts.ACL.WarehouseContext;

namespace Shoniz.CostAccounting.FormulationContext.Domain.Services.FormulationAggregate
{
    public class WarehouseProvider : IWarehoueProvider
    {
        private readonly IWarehouseAclService warehouseAclService;

        public WarehouseProvider(IWarehouseAclService warehouseAclService)
        {
            this.warehouseAclService = warehouseAclService;
        }

        public bool IsGoodsCodeValid(Guid id)
        {
            return warehouseAclService.IsGoodsCodeValid(id);
        }
    }
}
