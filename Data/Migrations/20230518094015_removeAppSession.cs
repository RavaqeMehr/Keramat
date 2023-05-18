using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class removeAppSession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntityChanges_AppSessions_AppSessionId",
                table: "EntityChanges");

            migrationBuilder.DropTable(
                name: "AppSessions");

            migrationBuilder.DropIndex(
                name: "IX_EntityChanges_AppSessionId",
                table: "EntityChanges");

            migrationBuilder.DropColumn(
                name: "AppSessionId",
                table: "EntityChanges");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppSessionId",
                table: "EntityChanges",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AppSessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DurationSeconds = table.Column<int>(type: "INTEGER", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDateD = table.Column<int>(type: "INTEGER", nullable: false),
                    EndDateM = table.Column<int>(type: "INTEGER", nullable: false),
                    EndDateY = table.Column<int>(type: "INTEGER", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    StartDateD = table.Column<int>(type: "INTEGER", nullable: false),
                    StartDateM = table.Column<int>(type: "INTEGER", nullable: false),
                    StartDateY = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSessions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntityChanges_AppSessionId",
                table: "EntityChanges",
                column: "AppSessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_EntityChanges_AppSessions_AppSessionId",
                table: "EntityChanges",
                column: "AppSessionId",
                principalTable: "AppSessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
