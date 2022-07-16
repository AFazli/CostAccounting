using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shoniz.CostAccounting.Database.Migrations
{
    public partial class AddCalculateFormulationColumnsInFormulationDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CalculateFormulation_DroppedAmount",
                schema: "FormulationContext",
                table: "FormulationDetails",
                type: "Decimal",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CalculateFormulation_DroppedPercent",
                schema: "FormulationContext",
                table: "FormulationDetails",
                type: "Decimal",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CalculateFormulation_UsedPercent",
                schema: "FormulationContext",
                table: "FormulationDetails",
                type: "Decimal",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CalculateFormulation_DroppedAmount",
                schema: "FormulationContext",
                table: "FormulationDetails");

            migrationBuilder.DropColumn(
                name: "CalculateFormulation_DroppedPercent",
                schema: "FormulationContext",
                table: "FormulationDetails");

            migrationBuilder.DropColumn(
                name: "CalculateFormulation_UsedPercent",
                schema: "FormulationContext",
                table: "FormulationDetails");
        }
    }
}
