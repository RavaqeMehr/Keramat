using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class fixFamilyLevelNavProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Level",
                table: "Families",
                newName: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Families_LevelId",
                table: "Families",
                column: "LevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Families_FamilyLevels_LevelId",
                table: "Families",
                column: "LevelId",
                principalTable: "FamilyLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Families_FamilyLevels_LevelId",
                table: "Families");

            migrationBuilder.DropIndex(
                name: "IX_Families_LevelId",
                table: "Families");

            migrationBuilder.RenameColumn(
                name: "LevelId",
                table: "Families",
                newName: "Level");
        }
    }
}
