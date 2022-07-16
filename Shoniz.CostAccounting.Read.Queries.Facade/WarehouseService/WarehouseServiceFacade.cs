using Shoniz.CostAccounting.Read.Queries.Contracts.WarehouseService;
using Shoniz.CostAccounting.Read.Queries.Contracts.WarehouseService.Dto;
using System.Net.Http.Json;

namespace Shoniz.CostAccounting.Read.Queries.Facade.WarehouseService
{
    public class WarehouseServiceFacade : IWarehouseServiceFacade
    {
        public async Task<GoodsCodingDto> GetCodingByGoodsCode(string goodsCode)
        {
            var client = new HttpClient();
            var response = client.GetAsync($"http://192.168.0.16:1004/Service.svc/json/GetCodingByGoodsCode/{goodsCode}").Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.Content.ReadAsStringAsync().Result);
            }

            var result = response.Content.ReadFromJsonAsync<GoodsCodingDto>().Result;

            return result;
        }
    }
}
