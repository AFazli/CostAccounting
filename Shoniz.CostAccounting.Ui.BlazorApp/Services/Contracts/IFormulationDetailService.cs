using Shoniz.CostAccounting.Read.Queries.Contracts.FormulationContext.FormulationAggregate.Dtos;

namespace Shoniz.CostAccounting.Ui.BlazorApp.Services.Contracts
{
    public interface IFormulationDetailService
    {
        Task<IEnumerable<FormulationDetailDto>> GetFormulationDetails(Guid formulationId);
        Task<FormulationDetailDto> DeleteFormulationDetail(Guid id);
    }
}
