using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Order.API.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTelemetryAndPriorityFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PriorityScore",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriorityScore",
                table: "Orders");
        }
    }
}
