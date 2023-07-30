using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TN.PhoneManagment.Api.Migrations
{
    /// <inheritdoc />
    public partial class smartphonemanagement14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SmartPhoneId",
                table: "orders");

            migrationBuilder.AddColumn<string>(
                name: "StatusName",
                table: "orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "orderPhones",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SmartPhoneId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CorrelationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderPhones", x => new { x.OrderId, x.SmartPhoneId });
                    table.ForeignKey(
                        name: "FK_orderPhones_orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "orders",
                        principalColumn: "CorrelationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orderPhones_phones_SmartPhoneId",
                        column: x => x.SmartPhoneId,
                        principalTable: "phones",
                        principalColumn: "CorrelationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_orderPhones_SmartPhoneId",
                table: "orderPhones",
                column: "SmartPhoneId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orderPhones");

            migrationBuilder.DropColumn(
                name: "StatusName",
                table: "orders");

            migrationBuilder.AddColumn<Guid>(
                name: "SmartPhoneId",
                table: "orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
