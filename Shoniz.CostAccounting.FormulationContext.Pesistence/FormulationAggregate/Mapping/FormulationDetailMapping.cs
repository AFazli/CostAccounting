using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shoniz.Framework.Persistence;
using Shoniz.CostAccounting.FormulationContext.Domain.FormulationAggregate;
using Shoniz.CostAccounting.FormulationContext.Pesistence.ValueObjects;

namespace Shoniz.CostAccounting.FormulationContext.Pesistence.FormulationAggregate.Mapping
{
    public class FormulationDetailMapping : EntityMappingBase<FormulationDetail>
    {
        private SignatureMapper<FormulationDetail> signatureMapper;

        public FormulationDetailMapping()
        {
            signatureMapper = new SignatureMapper<FormulationDetail>();
        }

        protected override void OnConfigure(EntityTypeBuilder<FormulationDetail> builder)
        {
            builder.Property(p => p.GoodsCode).HasColumnType(SqlDbType.UniqueIdentifier.ToString()).IsRequired();
            builder.Property(p => p.UsedAmount).HasColumnType(SqlDbType.Decimal.ToString()).IsRequired().HasDefaultValueSql("0");
            builder.Property(p => p.Mammock).HasColumnType(SqlDbType.Decimal.ToString()).IsRequired().HasDefaultValueSql("0");

            builder.OwnsOne(a => a.CalculateFormulation, navigationBuilder =>
            {
                navigationBuilder.Property(p => p.UsedPercent).HasColumnType(SqlDbType.Decimal.ToString());
                navigationBuilder.Property(p => p.DroppedAmount).HasColumnType(SqlDbType.Decimal.ToString());
                navigationBuilder.Property(p => p.DroppedPercent).HasColumnType(SqlDbType.Decimal.ToString());
                builder.OwnsOne(a => a.Registrar, signatureMapper.SignatureMapping);
            });
        }
    }
}
