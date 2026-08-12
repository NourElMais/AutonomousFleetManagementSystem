using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Order.API.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Orders",
                newName: "Number");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Orders",
                newName: "Name");
        }
    }
}
