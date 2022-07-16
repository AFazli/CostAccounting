using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shoniz.Framework.Persistence;
using Shoniz.CostAccounting.FormulationContext.Domain.FormulationAggregate;
using Shoniz.CostAccounting.FormulationContext.Pesistence.ValueObjects;

namespace Shoniz.CostAccounting.FormulationContext.Pesistence.FormulationAggregate.Mapping
{
    public class FormulationMapping : EntityMappingBase<Formulation>
    {

        private SignatureMapper<Formulation> signatureMapper;

        public FormulationMapping()
        {
            signatureMapper = new SignatureMapper<Formulation>();
        }

        protected override void OnConfigure(EntityTypeBuilder<Formulation> builder)
        {
            builder.Property(p => p.StartDate).HasColumnType(SqlDbType.DateTime2.ToString()).IsRequired();
            builder.Property(p => p.HumidityPercent).HasColumnType(SqlDbType.Decimal.ToString()).IsRequired().HasDefaultValueSql("0");
            builder.Property(p => p.ProductCode).HasColumnType(SqlDbType.UniqueIdentifier.ToString()).IsRequired();
            builder.Property(p => p.Scale).HasColumnType(SqlDbType.Decimal.ToString()).IsRequired().HasDefaultValueSql("0");
            builder.OwnsOne(a => a.Regulator, signatureMapper.SignatureMapping);
            builder.OwnsOne(a => a.Confirmer, signatureMapper.SignatureMapping);
        }
    }
}
