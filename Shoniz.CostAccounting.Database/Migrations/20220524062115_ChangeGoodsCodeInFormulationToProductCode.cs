using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shoniz.CostAccounting.Database.Migrations
{
    public partial class ChangeGoodsCodeInFormulationToProductCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GoodsCode",
                schema: "FormulationContext",
                table: "Formulations",
                newName: "ProductCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductCode",
                schema: "FormulationContext",
                table: "Formulations",
                newName: "GoodsCode");
        }
    }
}
