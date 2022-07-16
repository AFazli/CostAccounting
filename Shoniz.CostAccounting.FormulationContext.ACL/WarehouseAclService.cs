using Shoniz.CostAccounting.FormulationContext.Facade.Contracts.ACL.WarehouseContext;
using System.Net.Http.Json;

namespace Shoniz.CostAccounting.FormulationContext.ACL
{
    public class WarehouseAclService : IWarehouseAclService
    {
        public bool IsGoodsCodeValid(Guid id)
        {
            var client = new HttpClient();
            var response = client.GetAsync($"http://192.168.0.16:1004/Service.svc/json/IsGoodsCodeValid/{id}").Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.Content.ReadAsStringAsync().Result);
            }

            var result = response.Content.ReadFromJsonAsync<bool>().Result;

            return result;
        }
    }
}