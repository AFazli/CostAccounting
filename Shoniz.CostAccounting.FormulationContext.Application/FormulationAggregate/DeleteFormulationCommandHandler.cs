using Shoniz.CostAccounting.FormulationContext.Application.Contracts.FormulationAggregate;
using Shoniz.CostAccounting.FormulationContext.Domain.FormulationAggregate.Services;
using Shoniz.Framework.Application;

namespace Shoniz.CostAccounting.FormulationContext.Application.FormulationAggregate
{
    public class DeleteFormulationCommandHandler : ICommandHandler<DeleteFormulationCommand>
    {
        private readonly IFormulationRepository formulationRepository;

        public DeleteFormulationCommandHandler(IFormulationRepository formulationRepository)
        {
            this.formulationRepository = formulationRepository;
        }

        public void Execute(DeleteFormulationCommand command)
        {
            var formulation = formulationRepository.Get(command.FormulationId);

            formulation.CheckIfReadyForDelete();

            formulationRepository.Delete(formulation);
        }
    }
}
