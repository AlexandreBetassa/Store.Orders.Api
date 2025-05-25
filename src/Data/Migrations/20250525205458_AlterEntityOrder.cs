using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fatec.Store.Orders.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AlterEntityOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalPayment",
                table: "Orders",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPayment",
                table: "Orders");
        }
    }
}
