using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace codedash.Server.Migrations.ProblemDb
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
                values: new object[] { "09bceebe-e9f4-4e2e-8d5e-121f9a32e642", "print(\"Hi\")\nprint(0-1\"Hello, World!\"113)0-1", 0, false, "Hi\nHello, World!", "Sample 0" });

            migrationBuilder.InsertData(
                table: "Problem",
                columns: new[] { "Id", "Chunks", "Difficulty", "IsUserMade", "Output", "Title" },
                values: new object[] { "f412592f-9669-4f66-99c9-3381710de524", "for i in range(6):\n    print(0-1\"ay\"16, end='')\nprint('9')\n\nprint('ay' * 64 + '9')0-1", 0, false, "ayayayayayay9\nayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayayay9", "Sample 1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Problem");
        }
    }
}
