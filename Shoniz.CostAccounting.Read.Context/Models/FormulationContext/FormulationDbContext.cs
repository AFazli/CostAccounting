using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Shoniz.CostAccounting.Read.Context.Models.FormulationContext
{
    public partial class FormulationDbContext : DbContext
    {
        public FormulationDbContext()
        {
        }

        public FormulationDbContext(DbContextOptions<FormulationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Formulation> Formulations { get; set; } = null!;
        public virtual DbSet<FormulationDetail> FormulationDetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=192.168.0.41;Initial Catalog=CostAccounting_Test;Persist Security Info=True;User ID=sa;Password=#529a925#;MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Formulation>(entity =>
            {
                entity.ToTable("Formulations", "FormulationContext");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ConfirmerDateTime)
                    .HasColumnName("Confirmer_DateTime")
                    .HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

                entity.Property(e => e.ConfirmerUserId)
                    .HasMaxLength(10)
                    .HasColumnName("Confirmer_UserId")
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.HumidityPercent).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.RegulatorDateTime)
                    .HasColumnName("Regulator_DateTime")
                    .HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

                entity.Property(e => e.RegulatorUserId)
                    .HasMaxLength(10)
                    .HasColumnName("Regulator_UserId")
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Scale).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<FormulationDetail>(entity =>
            {
                entity.ToTable("FormulationDetails", "FormulationContext");

                entity.HasIndex(e => e.FormulationId, "IX_FormulationDetails_FormulationId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CalculateFormulationDroppedAmount)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("CalculateFormulation_DroppedAmount");

                entity.Property(e => e.CalculateFormulationDroppedPercent)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("CalculateFormulation_DroppedPercent");

                entity.Property(e => e.CalculateFormulationUsedPercent)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("CalculateFormulation_UsedPercent");

                entity.Property(e => e.Mammock).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.RegistrarDateTime)
                    .HasColumnName("Registrar_DateTime")
                    .HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

                entity.Property(e => e.RegistrarUserId)
                    .HasMaxLength(10)
                    .HasColumnName("Registrar_UserId")
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.UsedAmount).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Formulation)
                    .WithMany(p => p.FormulationDetails)
                    .HasForeignKey(d => d.FormulationId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
