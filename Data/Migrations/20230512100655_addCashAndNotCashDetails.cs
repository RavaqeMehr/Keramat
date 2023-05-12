using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class addCashAndNotCashDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Kheyrs",
                newName: "NotCashValue");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Kheyrs",
                newName: "NotCashDescription");

            migrationBuilder.AddColumn<int>(
                name: "CashAndNotCashValues",
                table: "Kheyrs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CashDescription",
                table: "Kheyrs",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CashValue",
                table: "Kheyrs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "HasCash",
                table: "Kheyrs",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasNotCash",
                table: "Kheyrs",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CashAndNotCashValues",
                table: "Kheyrs");

            migrationBuilder.DropColumn(
                name: "CashDescription",
                table: "Kheyrs");

            migrationBuilder.DropColumn(
                name: "CashValue",
                table: "Kheyrs");

            migrationBuilder.DropColumn(
                name: "HasCash",
                table: "Kheyrs");

            migrationBuilder.DropColumn(
                name: "HasNotCash",
                table: "Kheyrs");

            migrationBuilder.RenameColumn(
                name: "NotCashValue",
                table: "Kheyrs",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "NotCashDescription",
                table: "Kheyrs",
                newName: "Description");
        }
    }
}
