using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fatec.Store.Orders.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class OwnsOneFormOfPayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormOfPayment_Orders_OrderId",
                table: "FormOfPayment");

            migrationBuilder.DropIndex(
                name: "IX_FormOfPayment_OrderId",
                table: "FormOfPayment");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "FormOfPayment");

            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "FormOfPayment",
                newName: "Amount");

            migrationBuilder.AddColumn<int>(
                name: "FormOfPaymentId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_FormOfPaymentId",
                table: "Orders",
                column: "FormOfPaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_FormOfPayment_FormOfPaymentId",
                table: "Orders",
                column: "FormOfPaymentId",
                principalTable: "FormOfPayment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_FormOfPayment_FormOfPaymentId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_FormOfPaymentId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FormOfPaymentId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "FormOfPayment",
                newName: "TotalAmount");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "FormOfPayment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FormOfPayment_OrderId",
                table: "FormOfPayment",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_FormOfPayment_Orders_OrderId",
                table: "FormOfPayment",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
