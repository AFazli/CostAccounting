using Shoniz.CostAccounting.FormulationContext.Application.Contracts.FormulationAggregate;
using Shoniz.CostAccounting.FormulationContext.Domain.FormulationAggregate.Services;
using Shoniz.Framework.Application;

namespace Shoniz.CostAccounting.FormulationContext.Application.FormulationAggregate
{
    public class DeleteFormulationDetailCommandHandler : ICommandHandler<DeleteFormulationDetailCommand>
    {
        private readonly IFormulationRepository formulationRepository;

        public DeleteFormulationDetailCommandHandler(IFormulationRepository formulationRepository)
        {
            this.formulationRepository = formulationRepository;
        }

        public void Execute(DeleteFormulationDetailCommand command)
        {
            var formulation = formulationRepository.Get(command.FormulationId);

            formulation.DeleteDetail(command.FormulationDetailId);
        }
    }
}
