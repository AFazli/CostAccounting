using Shoniz.CostAccounting.Read.Queries.Contracts.WarehouseService.Dto;
using Shoniz.Framework.Read;

namespace Shoniz.CostAccounting.Read.Queries.Contracts.WarehouseService
{
    public interface IWarehouseServiceFacade : IQueryFacade
    {
        Task<GoodsCodingDto> GetCodingByGoodsCode(string goodsCode);
    }
}
