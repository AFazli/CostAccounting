using Shoniz.CostAccounting.FormulationContext.Application.Contracts.FormulationAggregate;
using Shoniz.CostAccounting.Read.Queries.Contracts.FormulationContext.FormulationAggregate.Dtos;

namespace Shoniz.CostAccounting.Ui.BlazorApp.Services.Contracts
{
    public interface IFormulationService
    {
        Task<IEnumerable<FormulationDto>> GetFormulations();
        Task<FormulationDto> GetFormulation(Guid id);
        Task<FormulationDto> CreateFormulation(CreateFormulationCommand command);
        Task<FormulationDto> DeleteFormulation(Guid id);
        Task<FormulationDto> RegulateFormulation(RegulateFormulationCommand command);
        Task<FormulationDto> RemoveRegulateFormulation(RemoveRegulateFormulationCommand command);
        Task<FormulationDto> ConfirmFormulation(ConfirmFormulationCommand command);
        Task<FormulationDto> RemoveConfirmFormulation(RemoveConfirmFormulationCommand command);
    }
}
