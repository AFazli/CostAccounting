using Shoniz.CostAccounting.FormulationContext.Application.Contracts.FormulationAggregate;
using Shoniz.CostAccounting.FormulationContext.Domain.FormulationAggregate;
using Shoniz.CostAccounting.FormulationContext.Domain.FormulationAggregate.Services;
using Shoniz.Framework.Application;

namespace Shoniz.CostAccounting.FormulationContext.Application.FormulationAggregate
{
    public class CreateFormulationCommandHandler : ICommandHandler<CreateFormulationCommand>
    {
        private readonly IFormulationRepository formulationRepository;
        private readonly IDuplicatedProductCodeAndStartDateChecker duplicatedGoodsCodeAndStartDateChecker;
        private readonly IWarehoueProvider warehoueProvider;

        public CreateFormulationCommandHandler(
            IFormulationRepository formulationRepository,
            IDuplicatedProductCodeAndStartDateChecker duplicatedGoodsCodeAndStartDateChecker,
            IWarehoueProvider warehoueProvider
            )
        {
            this.formulationRepository = formulationRepository;
            this.duplicatedGoodsCodeAndStartDateChecker = duplicatedGoodsCodeAndStartDateChecker;
            this.warehoueProvider = warehoueProvider;
        }

        public void Execute(CreateFormulationCommand command)
        {
            var formulation = new Formulation(
                duplicatedGoodsCodeAndStartDateChecker,
                warehoueProvider,
                command.StartDate,
                command.HumidityPercent,
                command.ProductCode,
                command.Scale);

            formulationRepository.Add(formulation);
        }
    }
}
