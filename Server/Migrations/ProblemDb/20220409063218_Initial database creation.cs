using System;
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
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
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
                values: new object[] { new Guid("49fadfb5-e6a6-4e96-9f63-81eabe41efc3"), "print(\"Hi\")\nprint(0-1\"Hello, World!\"113)0-1", 0, "Sample 0" });

            migrationBuilder.InsertData(
                table: "Problem",
                columns: new[] { "Id", "Chunks", "Difficulty", "Title" },
                values: new object[] { new Guid("b32f0e8d-4a60-4b0b-a575-76f767dd7687"), "for i in range(6):\n    print(0-1\"ay\"16, end='')\nprint('9')\n\nprint('ay' * 64 + '9')0-1", 0, "Sample 1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Problem");
        }
    }
}
