using Shoniz.CostAccounting.FormulationContext.Application.Contracts.FormulationAggregate;
using Shoniz.CostAccounting.FormulationContext.Facade.Contracts;
using Shoniz.Framework.Core.Application;
using Shoniz.Framework.Facade;

namespace Shoniz.CostAccounting.FormulationContext.Facade
{
    public class FormulationCommandFacade : FacadeCommandBase, IFormulationCommandFacade
    {
        public FormulationCommandFacade(ICommandBus commandBus) : base(commandBus)
        {
        }

        public void ConfirmFormulation(ConfirmFormulationCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void CreateFormulation(CreateFormulationCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void CreateFormulationDetail(AddFormulationDetailCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void DeleteFormulation(DeleteFormulationCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void DeleteFormulationDetail(DeleteFormulationDetailCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void RegulateFormulation(RegulateFormulationCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void RemoveConfirmFormulation(RemoveConfirmFormulationCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void RemoveRegulateFormulation(RemoveRegulateFormulationCommand command)
        {
            CommandBus.Dispatch(command);
        }
    }
}
