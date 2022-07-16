using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shoniz.CostAccounting.FormulationContext.Domain.Shared.ValueObjects.Signature;
using Shoniz.Framework.Domain;
using System.Data;

namespace Shoniz.CostAccounting.FormulationContext.Pesistence.ValueObjects
{
    public class SignatureMapper<T>
        where T : EntityBase
    {
        public Action<OwnedNavigationBuilder<T, Signature>> SignatureMapping => c =>
        {
            c.Property(p => p.UserId).HasColumnType("nvarchar(10)");
            c.Property(p => p.DateTime).HasColumnType(SqlDbType.DateTime2.ToString());
        };
    }
}