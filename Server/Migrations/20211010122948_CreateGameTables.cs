using Microsoft.EntityFrameworkCore.Migrations;

namespace ReimaginedAdventure.Server.Migrations
{
    public partial class CreateGameTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameTables",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    IdentityUser = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameTables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameTables_AspNetUsers_IdentityUser",
                        column: x => x.IdentityUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameTables_IdentityUser",
                table: "GameTables",
                column: "IdentityUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameTables");
        }
    }
}
