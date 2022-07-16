using Shoniz.CostAccounting.FormulationContext.Application.Contracts.FormulationAggregate;

namespace Shoniz.CostAccounting.FormulationContext.Facade.Contracts
{
    public interface IFormulationCommandFacade
    {
        void CreateFormulation(CreateFormulationCommand command);
        void CreateFormulationDetail(AddFormulationDetailCommand command);
        void DeleteFormulation(DeleteFormulationCommand command);
        void DeleteFormulationDetail(DeleteFormulationDetailCommand command);
        void RegulateFormulation(RegulateFormulationCommand command);
        void RemoveRegulateFormulation(RemoveRegulateFormulationCommand command);
        void ConfirmFormulation(ConfirmFormulationCommand command);
        void RemoveConfirmFormulation(RemoveConfirmFormulationCommand command);
    }
}
