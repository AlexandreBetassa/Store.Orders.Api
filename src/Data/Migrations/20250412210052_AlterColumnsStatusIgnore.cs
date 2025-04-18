using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fatec.Store.Orders.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AlterColumnsStatusIgnore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "ProductOrders");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "FormOfPayment");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Addresses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "ProductOrders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "FormOfPayment",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Contact",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Addresses",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
