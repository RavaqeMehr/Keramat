using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class addServicesEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceSubjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceSubjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceProvideds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ServiceSubjectId = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateY = table.Column<int>(type: "INTEGER", nullable: false),
                    DateM = table.Column<int>(type: "INTEGER", nullable: false),
                    DateD = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProvideds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceProvideds_ServiceSubjects_ServiceSubjectId",
                        column: x => x.ServiceSubjectId,
                        principalTable: "ServiceSubjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceRecivers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FamilyId = table.Column<int>(type: "INTEGER", nullable: false),
                    ServiceProvidedId = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRecivers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceRecivers_Families_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "Families",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceRecivers_ServiceProvideds_ServiceProvidedId",
                        column: x => x.ServiceProvidedId,
                        principalTable: "ServiceProvideds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProvideds_ServiceSubjectId",
                table: "ServiceProvideds",
                column: "ServiceSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRecivers_FamilyId",
                table: "ServiceRecivers",
                column: "FamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRecivers_ServiceProvidedId",
                table: "ServiceRecivers",
                column: "ServiceProvidedId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceRecivers");

            migrationBuilder.DropTable(
                name: "ServiceProvideds");

            migrationBuilder.DropTable(
                name: "ServiceSubjects");
        }
    }
}
