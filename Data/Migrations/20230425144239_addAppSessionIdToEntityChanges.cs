using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class addAppSessionIdToEntityChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppSessionId",
                table: "EntityChanges",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntityChanges_AppSessions_AppSessionId",
                table: "EntityChanges");

            migrationBuilder.DropIndex(
                name: "IX_EntityChanges_AppSessionId",
                table: "EntityChanges");

            migrationBuilder.DropColumn(
                name: "AppSessionId",
                table: "EntityChanges");
        }
    }
}
