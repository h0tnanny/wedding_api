using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wedding.API.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "wedding");

            migrationBuilder.CreateTable(
                name: "guest_form",
                schema: "wedding",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    HelpSelectors = table.Column<int[]>(type: "integer[]", nullable: true),
                    Preferences = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_guest_form", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "welcome",
                schema: "wedding",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Key = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_welcome", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_welcome_Key",
                schema: "wedding",
                table: "welcome",
                column: "Key");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "guest_form",
                schema: "wedding");

            migrationBuilder.DropTable(
                name: "welcome",
                schema: "wedding");
        }
    }
}
