using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Codedash.Server.Migrations.ProblemDb
{
    public partial class Initialdatabasecreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Problem",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Chunks = table.Column<string>(type: "TEXT", nullable: true),
                    Output = table.Column<string>(type: "TEXT", nullable: true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Difficulty = table.Column<int>(type: "INTEGER", nullable: false),
                    IsUserMade = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Problem", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Problem",
                columns: new[] { "Id", "Chunks", "Difficulty", "IsUserMade", "Output", "Title" },
                values: new object[] { "366f6e22-efd0-4e12-98af-99145881ccf3", "for i in range(6):\n    print(0-1\"ay\"16, end='')\nprint('9')\n\nprint('ay' * 64 + '9')0-1", 0, false, "ayayayayayay9\nayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayay9", "Sample 1" });

            migrationBuilder.InsertData(
                table: "Problem",
                columns: new[] { "Id", "Chunks", "Difficulty", "IsUserMade", "Output", "Title" },
                values: new object[] { "fbfc9038-b902-40e8-b0b4-fe3b11beb1c4", "print(\"Hi\")\nprint(0-1\"Hello, World!\"113)0-1", 0, false, "Hi\nHello, World!", "Sample 0" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Problem");
        }
    }
}
