using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smart_Warehouse.Migrations
{
    /// <inheritdoc />
    public partial class NavigationWarehouseExport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Exports_WarehouseId",
                table: "Exports",
                column: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exports_Warehouses_WarehouseId",
                table: "Exports",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exports_Warehouses_WarehouseId",
                table: "Exports");

            migrationBuilder.DropIndex(
                name: "IX_Exports_WarehouseId",
                table: "Exports");
        }
    }
}
