using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class addEntityChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EntityChanges",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateY = table.Column<int>(type: "INTEGER", nullable: false),
                    DateM = table.Column<int>(type: "INTEGER", nullable: false),
                    DateD = table.Column<int>(type: "INTEGER", nullable: false),
                    ChangeType = table.Column<int>(type: "INTEGER", nullable: false),
                    EnitityType = table.Column<int>(type: "INTEGER", nullable: false),
                    EnitityId = table.Column<int>(type: "INTEGER", nullable: false),
                    Root1Id = table.Column<int>(type: "INTEGER", nullable: true),
                    Root2Id = table.Column<int>(type: "INTEGER", nullable: true),
                    Root3Id = table.Column<int>(type: "INTEGER", nullable: true),
                    Changes = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityChanges", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntityChanges");
        }
    }
}
