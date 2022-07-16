using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shoniz.CostAccounting.Database.Migrations
{
    public partial class AddSignaturesInFormulation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Confirmer_DateTime",
                schema: "FormulationContext",
                table: "Formulations",
                type: "DateTime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Confirmer_UserId",
                schema: "FormulationContext",
                table: "Formulations",
                type: "nvarchar(10)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Regulator_DateTime",
                schema: "FormulationContext",
                table: "Formulations",
                type: "DateTime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Regulator_UserId",
                schema: "FormulationContext",
                table: "Formulations",
                type: "nvarchar(10)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Scale",
                schema: "FormulationContext",
                table: "Formulations",
                type: "Decimal",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<DateTime>(
                name: "Registrar_DateTime",
                schema: "FormulationContext",
                table: "FormulationDetails",
                type: "DateTime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Registrar_UserId",
                schema: "FormulationContext",
                table: "FormulationDetails",
                type: "nvarchar(10)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Confirmer_DateTime",
                schema: "FormulationContext",
                table: "Formulations");

            migrationBuilder.DropColumn(
                name: "Confirmer_UserId",
                schema: "FormulationContext",
                table: "Formulations");

            migrationBuilder.DropColumn(
                name: "Regulator_DateTime",
                schema: "FormulationContext",
                table: "Formulations");

            migrationBuilder.DropColumn(
                name: "Regulator_UserId",
                schema: "FormulationContext",
                table: "Formulations");

            migrationBuilder.DropColumn(
                name: "Scale",
                schema: "FormulationContext",
                table: "Formulations");

            migrationBuilder.DropColumn(
                name: "Registrar_DateTime",
                schema: "FormulationContext",
                table: "FormulationDetails");

            migrationBuilder.DropColumn(
                name: "Registrar_UserId",
                schema: "FormulationContext",
                table: "FormulationDetails");
        }
    }
}
