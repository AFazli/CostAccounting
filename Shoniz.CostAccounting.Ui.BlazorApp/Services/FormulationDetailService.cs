using Shoniz.CostAccounting.Read.Queries.Contracts.FormulationContext.FormulationAggregate.Dtos;
using Shoniz.CostAccounting.Ui.BlazorApp.Services.Contracts;
using System.Net.Http.Json;

namespace Shoniz.CostAccounting.Ui.BlazorApp.Services
{
    public class FormulationDetailService : IFormulationDetailService
    {
        private readonly HttpClient httpClient;
        private string url = "api/FormulationDetail";

        public FormulationDetailService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<FormulationDetailDto>> GetFormulationDetails(Guid formulationId)
        {
            try
            {
                var response = await this.httpClient.GetAsync($"{url}/{formulationId}");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<FormulationDetailDto>();
                    }

                    return await response.Content.ReadFromJsonAsync<IEnumerable<FormulationDetailDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {response.StatusCode} message: {message}");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<FormulationDetailDto> DeleteFormulationDetail(Guid id)
        {
            try
            {
                var response = await this.httpClient.DeleteAsync($"{url}/{id}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<FormulationDetailDto>();
                }

                return default(FormulationDetailDto);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
