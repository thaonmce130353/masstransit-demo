using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TN.PhoneManagment.Api.Migrations
{
    /// <inheritdoc />
    public partial class smartphonemanagement11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_phones_SmartPhoneId",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_SmartPhoneId",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "SmartPhoneId",
                table: "orders");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "orders",
                newName: "totalPrice");

            migrationBuilder.AddColumn<Guid>(
                name: "orderId",
                table: "phones",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_phones_orderId",
                table: "phones",
                column: "orderId");

            migrationBuilder.AddForeignKey(
                name: "FK_phones_orders_orderId",
                table: "phones",
                column: "orderId",
                principalTable: "orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_phones_orders_orderId",
                table: "phones");

            migrationBuilder.DropIndex(
                name: "IX_phones_orderId",
                table: "phones");

            migrationBuilder.DropColumn(
                name: "orderId",
                table: "phones");

            migrationBuilder.RenameColumn(
                name: "totalPrice",
                table: "orders",
                newName: "Price");

            migrationBuilder.AddColumn<Guid>(
                name: "SmartPhoneId",
                table: "orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_orders_SmartPhoneId",
                table: "orders",
                column: "SmartPhoneId");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_phones_SmartPhoneId",
                table: "orders",
                column: "SmartPhoneId",
                principalTable: "phones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
