using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shoniz.CostAccounting.Database.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "FormulationContext");

            migrationBuilder.CreateTable(
                name: "Formulations",
                schema: "FormulationContext",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    HumidityPercent = table.Column<decimal>(type: "Decimal", nullable: false, defaultValueSql: "0"),
                    GoodsCode = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "DateTime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formulations", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Formulations",
                schema: "FormulationContext");
        }
    }
}
