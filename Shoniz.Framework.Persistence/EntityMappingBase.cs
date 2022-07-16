using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shoniz.Framework.Domain;
using Shoniz.Framework.Utility;

namespace Shoniz.Framework.Persistence
{
    public abstract class EntityMappingBase<TEntity> : IEntityTypeConfiguration<TEntity>, IEntityMapping
        where TEntity : EntityBase
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(p => p.Id).HasColumnType(SqlDbType.UniqueIdentifier.ToString()).IsRequired().ValueGeneratedNever();
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Timestamp).HasColumnType(SqlDbType.DateTime2.ToString()).IsRequired();

            OnConfigure(builder);

            ToTable(builder);
        }

        protected abstract void OnConfigure(EntityTypeBuilder<TEntity> builder);

        private static void ToTable(EntityTypeBuilder<TEntity> builder)
        {
            var entityType = typeof(TEntity);

            var tableName = entityType.Name;
            var schemaName = entityType.Namespace.Split('.')[2];
            builder.ToTable(tableName.ToPlural(), schemaName);
        }
    }
}