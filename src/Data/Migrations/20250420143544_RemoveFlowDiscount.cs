using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fatec.Store.Orders.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveFlowDiscount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalDiscount",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TotalDiscount",
                table: "FormOfPayment");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "ProductOrders",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Orders",
                newName: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "ProductOrders",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Orders",
                newName: "CustomerId");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalDiscount",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalDiscount",
                table: "FormOfPayment",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
