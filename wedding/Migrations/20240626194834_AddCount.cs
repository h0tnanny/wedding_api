using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wedding.API.Migrations
{
    /// <inheritdoc />
    public partial class AddCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VisitingCount",
                schema: "wedding",
                table: "welcome",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VisitingCount",
                schema: "wedding",
                table: "welcome");
        }
    }
}
