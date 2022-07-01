using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiaryAPI.Migrations
{
    public partial class InitialCrreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "user first name"),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "user last name"),
                    RegisteredOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()", comment: "user registering date and time"),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, comment: "user email"),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "user password"),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "user username"),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true, comment: "user gender"),
                    IsActive = table.Column<bool>(type: "bit", maxLength: 250, nullable: true, defaultValue: true, comment: "user email")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayEvent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_UserId",
                table: "Notes",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
