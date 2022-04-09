using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace codedash.Server.Migrations
{
    public partial class Initialdatabasecreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UsernameHash = table.Column<string>(type: "TEXT", nullable: true),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    DisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    Solved = table.Column<int>(type: "INTEGER", nullable: false),
                    AverageTime = table.Column<decimal>(type: "TEXT", nullable: false),
                    SubmissionsNum = table.Column<int>(type: "INTEGER", nullable: false),
                    Submissions = table.Column<string>(type: "TEXT", nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "AverageTime", "DisplayName", "PasswordHash", "RegistrationDate", "Solved", "Submissions", "SubmissionsNum", "UsernameHash" },
                values: new object[] { "2023dcab-35c2-4975-b08c-83a67ff51d75", 0m, "Generic electron", "d2015c71296c09ac3279d2d27a35b0fd58bb39f5b184a160f52e39c495056494f2eae2c84bc90f24013580bf9e34c318c98c27a85d0b88e63f4ef4c695d6699b", new DateTime(2022, 4, 9, 8, 53, 42, 319, DateTimeKind.Utc).AddTicks(3620), 0, "", 0, "4a2bdfc8841a6b57e71e90983ccd34cd7c8950d2d59506c9df7565978d1891ab11c7c2fc8948d1109eb098e8d016e2d4999a404d0e15ae0ce5637b0482446c0e" });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "AverageTime", "DisplayName", "PasswordHash", "RegistrationDate", "Solved", "Submissions", "SubmissionsNum", "UsernameHash" },
                values: new object[] { "7b52cbc9-3343-437f-981d-70cc89a71ce5", 0m, "Generic PCI Device", "c2015c71296c09ac3279d2d27a35b0fd58bb39f5b184a160f52e39c495056494f2eae2c84bc90f24013580bf9e34c318c98c27a85d0b88e63f4ef4c695d6699b", new DateTime(2022, 4, 9, 8, 53, 42, 319, DateTimeKind.Utc).AddTicks(3597), 0, "", 0, "3a2bdfc8841a6b57e71e90983ccd34cd7c8950d2d59506c9df7565978d1891ab11c7c2fc8948d1109eb098e8d016e2d4999a404d0e15ae0ce5637b0482446c0e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");
        }
    }
}
