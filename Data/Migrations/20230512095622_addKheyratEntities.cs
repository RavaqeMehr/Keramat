using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class addKheyratEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NikooKars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Job = table.Column<string>(type: "TEXT", nullable: false),
                    JobDescription = table.Column<string>(type: "TEXT", nullable: false),
                    JobAddress = table.Column<string>(type: "TEXT", nullable: false),
                    JobPhone = table.Column<string>(type: "TEXT", nullable: false),
                    AddDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AddDateY = table.Column<int>(type: "INTEGER", nullable: false),
                    AddDateM = table.Column<int>(type: "INTEGER", nullable: false),
                    AddDateD = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NikooKars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kheyrs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NikooKarId = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateY = table.Column<int>(type: "INTEGER", nullable: false),
                    DateM = table.Column<int>(type: "INTEGER", nullable: false),
                    DateD = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kheyrs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kheyrs_NikooKars_NikooKarId",
                        column: x => x.NikooKarId,
                        principalTable: "NikooKars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kheyrs_NikooKarId",
                table: "Kheyrs",
                column: "NikooKarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kheyrs");

            migrationBuilder.DropTable(
                name: "NikooKars");
        }
    }
}
