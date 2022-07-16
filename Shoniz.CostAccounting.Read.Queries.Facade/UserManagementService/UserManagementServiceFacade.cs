using Newtonsoft.Json;
using Shoniz.CostAccounting.Read.Queries.Contracts.UserManagement;
using Shoniz.CostAccounting.Read.Queries.Contracts.UserManagementService.Dtos;
using System.Net;
using System.Net.Http.Headers;

namespace Shoniz.CostAccounting.Read.Queries.Facade.UserManagementService
{
    public class UserManagementServiceFacade : IUserManagementServiceFacade, IDisposable
    {
        private readonly HttpClient _httpClient;
        private readonly string url = "http://apihrms.dbi.com/HR/api/Employee/";

        public UserManagementServiceFacade()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(url);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public void Dispose()
        {
            _httpClient.Dispose();
        }

        public async Task<UserAccessInfoDto> GetUserAccessInfo(string programId)
        {
            try
            {
                string fileId = programId;
                string json = new WebClient().DownloadString("http://apihrms.dbi.com/HR/api/GetEmployeeInfoWithPhoto?employeeId=" + fileId);
                var obj = JsonConvert.DeserializeObject<UserAccessInfoDto>(json);

                return obj;
            }
            catch
            {
                return new UserAccessInfoDto();
            }
        }


    }
}
