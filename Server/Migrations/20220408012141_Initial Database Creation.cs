using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace codedash.Server.Migrations
{
    public partial class InitialDatabaseCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UsernameHash = table.Column<string>(type: "TEXT", nullable: true),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    DisplayName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "DisplayName", "PasswordHash", "UsernameHash" },
                values: new object[] { new Guid("006cda85-4ebe-4aac-8c58-65103508513f"), "Generic PCI Device", "c2015c71296c09ac3279d2d27a35b0fd58bb39f5b184a160f52e39c495056494f2eae2c84bc90f24013580bf9e34c318c98c27a85d0b88e63f4ef4c695d6699b", "3a2bdfc8841a6b57e71e90983ccd34cd7c8950d2d59506c9df7565978d1891ab11c7c2fc8948d1109eb098e8d016e2d4999a404d0e15ae0ce5637b0482446c0e" });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "DisplayName", "PasswordHash", "UsernameHash" },
                values: new object[] { new Guid("dcf4771f-c6a5-413d-be45-d4f054c08f9a"), "Generic electron", "d2015c71296c09ac3279d2d27a35b0fd58bb39f5b184a160f52e39c495056494f2eae2c84bc90f24013580bf9e34c318c98c27a85d0b88e63f4ef4c695d6699b", "4a2bdfc8841a6b57e71e90983ccd34cd7c8950d2d59506c9df7565978d1891ab11c7c2fc8948d1109eb098e8d016e2d4999a404d0e15ae0ce5637b0482446c0e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");
        }
    }
}
