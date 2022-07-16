using Shoniz.CostAccounting.Read.Queries.Contracts.FormulationContext.FormulationAggregate.Dtos;
using Shoniz.Framework.Read;

namespace Shoniz.CostAccounting.Read.Queries.Contracts.FormulationContext.FormulationAggregate
{
    public interface IFormulationQueryFacade : IQueryFacade
    {
        Task<IEnumerable<FormulationDto>> GetFormulations();
        Task<IEnumerable<FormulationDetailDto>> GetFormulationDetails(Guid formulationId);
        Task<FormulationDto> GetFormulation(Guid formulationId);
        Task<FormulationDetailDto> GetFormulationDetail(Guid formulationDetailId);
    }
}
