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
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Difficulty = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Problem", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Problem",
                columns: new[] { "Id", "Chunks", "Difficulty", "Title" },
                values: new object[] { "27aad10f-f8d2-4a4a-ab84-351eec0244e0", "for i in range(6):\n    print(0-1\"ay\"16, end='')\nprint('9')\n\nprint('ay' * 64 + '9')0-1", 0, "Sample 1" });

            migrationBuilder.InsertData(
                table: "Problem",
                columns: new[] { "Id", "Chunks", "Difficulty", "Title" },
                values: new object[] { "e9410cd7-c31d-4635-adcf-787c7e6f57b8", "print(\"Hi\")\nprint(0-1\"Hello, World!\"113)0-1", 0, "Sample 0" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Problem");
        }
    }
}
