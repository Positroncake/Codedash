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
                    Chunks = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Problem", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Problem",
                columns: new[] { "Id", "Chunks" },
                values: new object[] { new Guid("6b017c7b-660e-4780-ad01-519d28342938"), "print(\"Hi\")0-1\nprint(0-1Hello, World!113)0-1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Problem");
        }
    }
}
