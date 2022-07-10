using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DiaryAPI.Migrations
{
    public partial class initialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "user first name"),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "user last name"),
                    RegisteredOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "NOW()", comment: "user registering date and time"),
                    Email = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false, comment: "user email"),
                    Password = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "user password"),
                    Username = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "user username"),
                    Gender = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true, comment: "user gender"),
                    IsActive = table.Column<bool>(type: "boolean", maxLength: 250, nullable: true, defaultValue: true, comment: "user email")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DayEvent = table.Column<string>(type: "text", nullable: true),
                    AddedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
