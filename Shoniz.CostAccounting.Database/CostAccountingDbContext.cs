using Shoniz.CostAccounting.FormulationContext.Pesistence.FormulationAggregate.Mapping;
using Shoniz.Framework.Persistence;

namespace Shoniz.CostAccounting.Database
{
    public class CostAccountingDbContext : DbContextBase
    {
        protected override string GetConnectionString()
        {
            return "Data Source=WAREHOUSE;Initial Catalog=CostAccounting_Test;User ID=sa;Password=#529a925#";
        }

        protected override Type GetSampleEntityMappingType()
        {
            return typeof(FormulationMapping);
        }
    }
}