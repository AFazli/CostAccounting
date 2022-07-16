using Shoniz.CostAccounting.FormulationContext.Application.Contracts.FormulationAggregate;
using Shoniz.CostAccounting.FormulationContext.Domain.FormulationAggregate;
using Shoniz.CostAccounting.FormulationContext.Domain.FormulationAggregate.Services;
using Shoniz.Framework.Application;

namespace Shoniz.CostAccounting.FormulationContext.Application.FormulationAggregate
{
    public class AddFormulationDetailCommandHandler : ICommandHandler<AddFormulationDetailCommand>
    {
        private readonly IFormulationRepository formulationRepository;

        public AddFormulationDetailCommandHandler(IFormulationRepository formulationRepository)
        {
            this.formulationRepository = formulationRepository;
        }

        public void Execute(AddFormulationDetailCommand command)
        {
            var formulation = formulationRepository.Get(command.FormulationId);

            var formulationDetail = new FormulationDetail(
                command.GoodsCode,
                command.UsedAmount,
                command.Mammock,
                command.Registrar);

            formulation.AddFormulationDetail(formulationDetail);
        }
    }
}
