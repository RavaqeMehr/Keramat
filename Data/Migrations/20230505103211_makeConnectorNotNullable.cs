using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class makeConnectorNotNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Families_Connectors_ConnectorId",
                table: "Families");

            migrationBuilder.AlterColumn<int>(
                name: "ConnectorId",
                table: "Families",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Families_Connectors_ConnectorId",
                table: "Families",
                column: "ConnectorId",
                principalTable: "Connectors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Families_Connectors_ConnectorId",
                table: "Families");

            migrationBuilder.AlterColumn<int>(
                name: "ConnectorId",
                table: "Families",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Families_Connectors_ConnectorId",
                table: "Families",
                column: "ConnectorId",
                principalTable: "Connectors",
                principalColumn: "Id");
        }
    }
}
