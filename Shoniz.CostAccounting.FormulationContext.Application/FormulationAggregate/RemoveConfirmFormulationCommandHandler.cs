using Shoniz.CostAccounting.FormulationContext.Application.Contracts.FormulationAggregate;
using Shoniz.CostAccounting.FormulationContext.Domain.FormulationAggregate.Services;
using Shoniz.Framework.Application;

namespace Shoniz.CostAccounting.FormulationContext.Application.FormulationAggregate
{
    internal class RemoveConfirmFormulationCommandHandler : ICommandHandler<RemoveConfirmFormulationCommand>
    {
        private readonly IFormulationRepository formulationRepository;

        public RemoveConfirmFormulationCommandHandler(IFormulationRepository formulationRepository)
        {
            this.formulationRepository = formulationRepository;
        }

        public void Execute(RemoveConfirmFormulationCommand command)
        {
            var formlation = formulationRepository.Get(command.FormulationId);

            formlation.UnConfirm();
        }
    }
}
