using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shoniz.CostAccounting.Database.Migrations
{
    public partial class AddFormulationDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormulationDetails",
                schema: "FormulationContext",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    GoodsCode = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    UsedAmount = table.Column<decimal>(type: "Decimal", nullable: false, defaultValueSql: "0"),
                    Mammock = table.Column<decimal>(type: "Decimal", nullable: false, defaultValueSql: "0"),
                    FormulationId = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "DateTime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormulationDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormulationDetails_Formulations_FormulationId",
                        column: x => x.FormulationId,
                        principalSchema: "FormulationContext",
                        principalTable: "Formulations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FormulationDetails_FormulationId",
                schema: "FormulationContext",
                table: "FormulationDetails",
                column: "FormulationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormulationDetails",
                schema: "FormulationContext");
        }
    }
}
