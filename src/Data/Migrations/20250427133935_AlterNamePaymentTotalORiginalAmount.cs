using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fatec.Store.Orders.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AlterNamePaymentTotalORiginalAmount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "Payment",
                newName: "TotalOriginalAmount");

            migrationBuilder.AddColumn<string>(
                name: "DiscountCouponCode",
                table: "Payment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountCouponCode",
                table: "Payment");

            migrationBuilder.RenameColumn(
                name: "TotalOriginalAmount",
                table: "Payment",
                newName: "TotalAmount");
        }
    }
}
