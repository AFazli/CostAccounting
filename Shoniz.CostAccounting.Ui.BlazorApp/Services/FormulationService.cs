using Newtonsoft.Json;
using Shoniz.CostAccounting.FormulationContext.Application.Contracts.FormulationAggregate;
using Shoniz.CostAccounting.Read.Queries.Contracts.FormulationContext.FormulationAggregate.Dtos;
using Shoniz.CostAccounting.Ui.BlazorApp.Services.Contracts;
using System.Net.Http.Json;
using System.Text;

namespace Shoniz.CostAccounting.Ui.BlazorApp.Services
{
    public class FormulationService : IFormulationService
    {
        private readonly HttpClient httpClient;
        private string url = "api/Formulation";

        public FormulationService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<FormulationDto>> GetFormulations()
        {
            try
            {
                var response = await this.httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<FormulationDto>();
                    }

                    return await response.Content.ReadFromJsonAsync<IEnumerable<FormulationDto>>();
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

        public async Task<FormulationDto> GetFormulation(Guid formulationId)
        {
            try
            {
                var response = await httpClient.GetAsync($"{url}/{formulationId}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<FormulationDto>();
                }

                return default(FormulationDto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<FormulationDto> CreateFormulation(CreateFormulationCommand command)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync<CreateFormulationCommand>(url,command);

                if(response.IsSuccessStatusCode)
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(FormulationDto);
                    }

                    return await response.Content.ReadFromJsonAsync<FormulationDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status:{response.StatusCode} Message -{message}");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<FormulationDto> DeleteFormulation(Guid id)
        {
            try
            {
                var response = await httpClient.DeleteAsync($"{url}/{id}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<FormulationDto>();
                }

                return default(FormulationDto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<FormulationDto> RegulateFormulation(RegulateFormulationCommand command)
        {
            try
            {
                var jsonRequest = JsonConvert.SerializeObject(command);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json-patch+json");

                var response = await httpClient.PatchAsync($"{url}/Regulate",content);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<FormulationDto>();
                }

                return default(FormulationDto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<FormulationDto> RemoveRegulateFormulation(RemoveRegulateFormulationCommand command)
        {
            try
            {
                var jsonRequest = JsonConvert.SerializeObject(command);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json-patch+json");

                var response = await httpClient.PatchAsync($"{url}/RemoveRegulate", content);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<FormulationDto>();
                }

                return default(FormulationDto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<FormulationDto> ConfirmFormulation(ConfirmFormulationCommand command)
        {
            try
            {
                var jsonRequest = JsonConvert.SerializeObject(command);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json-patch+json");

                var response = await httpClient.PatchAsync($"{url}/Confirm", content);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<FormulationDto>();
                }

                return default(FormulationDto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<FormulationDto> RemoveConfirmFormulation(RemoveConfirmFormulationCommand command)
        {
            try
            {
                var jsonRequest = JsonConvert.SerializeObject(command);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json-patch+json");

                var response = await httpClient.PatchAsync($"{url}/RemoveConfirm", content);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<FormulationDto>();
                }

                return default(FormulationDto);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
