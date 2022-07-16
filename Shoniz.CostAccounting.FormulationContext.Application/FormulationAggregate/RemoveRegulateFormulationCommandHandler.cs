using Shoniz.CostAccounting.FormulationContext.Application.Contracts.FormulationAggregate;
using Shoniz.CostAccounting.FormulationContext.Domain.FormulationAggregate.Services;
using Shoniz.Framework.Application;

namespace Shoniz.CostAccounting.FormulationContext.Application.FormulationAggregate
{
    public class RemoveRegulateFormulationCommandHandler : ICommandHandler<RemoveRegulateFormulationCommand>
    {
        private readonly IFormulationRepository formulationRepository;

        public RemoveRegulateFormulationCommandHandler(IFormulationRepository formulationRepository)
        {
            this.formulationRepository = formulationRepository;
        }

        public void Execute(RemoveRegulateFormulationCommand command)
        {
            var formulation = formulationRepository.Get(command.FormulationId);

            formulation.UnRegulate();
        }
    }
}
