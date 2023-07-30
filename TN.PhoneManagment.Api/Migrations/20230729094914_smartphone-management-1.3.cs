using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TN.PhoneManagment.Api.Migrations
{
    /// <inheritdoc />
    public partial class smartphonemanagement13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "phones",
                newName: "CorrelationId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "orders",
                newName: "CorrelationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CorrelationId",
                table: "phones",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CorrelationId",
                table: "orders",
                newName: "Id");
        }
    }
}
