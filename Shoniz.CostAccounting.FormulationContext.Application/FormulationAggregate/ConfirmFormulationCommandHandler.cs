using Shoniz.CostAccounting.FormulationContext.Application.Contracts.FormulationAggregate;
using Shoniz.CostAccounting.FormulationContext.Domain.FormulationAggregate.Services;
using Shoniz.Framework.Application;

namespace Shoniz.CostAccounting.FormulationContext.Application.FormulationAggregate
{
    public class ConfirmFormulationCommandHandler : ICommandHandler<ConfirmFormulationCommand>
    {
        private readonly IFormulationRepository formulationRepository;

        public ConfirmFormulationCommandHandler(IFormulationRepository formulationRepository)
        {
            this.formulationRepository = formulationRepository;
        }

        public void Execute(ConfirmFormulationCommand command)
        {
            var formulation = formulationRepository.Get(command.FormulationId);

            formulation.Confirm(command.Confirmer);
        }
    }
}
