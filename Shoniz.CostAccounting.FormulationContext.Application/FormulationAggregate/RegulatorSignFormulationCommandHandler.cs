using Shoniz.CostAccounting.FormulationContext.Application.Contracts.FormulationAggregate;
using Shoniz.CostAccounting.FormulationContext.Domain.FormulationAggregate.Services;
using Shoniz.Framework.Application;

namespace Shoniz.CostAccounting.FormulationContext.Application.FormulationAggregate
{
    public class RegulatorSignFormulationCommandHandler : ICommandHandler<RegulateFormulationCommand>
    {
        private readonly IFormulationRepository formulationRepository;

        public RegulatorSignFormulationCommandHandler(IFormulationRepository formulationRepository)
        {
            this.formulationRepository = formulationRepository;
        }

        public void Execute(RegulateFormulationCommand command)
        {
            var formulation = formulationRepository.Get(command.FormulationId);

            formulation.Regulate(command.Regulator);
        }
    }
}
