using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class addValiNematanEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Connectors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Connectors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FamilyLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Level = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FamilyMemberNeedSubjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyMemberNeedSubjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FamilyMemberRelations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Order = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyMemberRelations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FamilyNeedSubjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyNeedSubjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Families",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    Level = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    ContactPersonName = table.Column<string>(type: "TEXT", nullable: true),
                    ContactPersonPhone = table.Column<string>(type: "TEXT", nullable: true),
                    ContactPersonDescription = table.Column<string>(type: "TEXT", nullable: true),
                    ConnectorId = table.Column<int>(type: "INTEGER", nullable: true),
                    AddDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AddDateY = table.Column<int>(type: "INTEGER", nullable: false),
                    AddDateM = table.Column<int>(type: "INTEGER", nullable: false),
                    AddDateD = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Families", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Families_Connectors_ConnectorId",
                        column: x => x.ConnectorId,
                        principalTable: "Connectors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FamilyMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FamilyId = table.Column<int>(type: "INTEGER", nullable: false),
                    FamilyMemberRelationId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Phone = table.Column<string>(type: "TEXT", nullable: true),
                    Job = table.Column<string>(type: "TEXT", nullable: true),
                    JobDescription = table.Column<string>(type: "TEXT", nullable: true),
                    JobAdrees = table.Column<string>(type: "TEXT", nullable: true),
                    JobPhone = table.Column<string>(type: "TEXT", nullable: true),
                    LiveStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    ImpreciseBirthDate = table.Column<string>(type: "TEXT", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    BirthDateY = table.Column<int>(type: "INTEGER", nullable: true),
                    BirthDateM = table.Column<int>(type: "INTEGER", nullable: true),
                    BirthDateD = table.Column<int>(type: "INTEGER", nullable: true),
                    ImpreciseDeathDate = table.Column<string>(type: "TEXT", nullable: true),
                    DeathDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeathDateY = table.Column<int>(type: "INTEGER", nullable: true),
                    DeathDateM = table.Column<int>(type: "INTEGER", nullable: true),
                    DeathDateD = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FamilyMembers_Families_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "Families",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FamilyMembers_FamilyMemberRelations_FamilyMemberRelationId",
                        column: x => x.FamilyMemberRelationId,
                        principalTable: "FamilyMemberRelations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FamilyNeeds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Order = table.Column<int>(type: "INTEGER", nullable: false),
                    FamilyNeedSubjectId = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    FamilyId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyNeeds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FamilyNeeds_Families_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "Families",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FamilyNeeds_FamilyNeedSubjects_FamilyNeedSubjectId",
                        column: x => x.FamilyNeedSubjectId,
                        principalTable: "FamilyNeedSubjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FamilyMemberNeeds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Order = table.Column<int>(type: "INTEGER", nullable: false),
                    FamilyMemberNeedSubjectId = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    FamilyMemberId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyMemberNeeds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FamilyMemberNeeds_FamilyMemberNeedSubjects_FamilyMemberNeedSubjectId",
                        column: x => x.FamilyMemberNeedSubjectId,
                        principalTable: "FamilyMemberNeedSubjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FamilyMemberNeeds_FamilyMembers_FamilyMemberId",
                        column: x => x.FamilyMemberId,
                        principalTable: "FamilyMembers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Families_ConnectorId",
                table: "Families",
                column: "ConnectorId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMemberNeeds_FamilyMemberId",
                table: "FamilyMemberNeeds",
                column: "FamilyMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMemberNeeds_FamilyMemberNeedSubjectId",
                table: "FamilyMemberNeeds",
                column: "FamilyMemberNeedSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMembers_FamilyId",
                table: "FamilyMembers",
                column: "FamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMembers_FamilyMemberRelationId",
                table: "FamilyMembers",
                column: "FamilyMemberRelationId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyNeeds_FamilyId",
                table: "FamilyNeeds",
                column: "FamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyNeeds_FamilyNeedSubjectId",
                table: "FamilyNeeds",
                column: "FamilyNeedSubjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FamilyLevels");

            migrationBuilder.DropTable(
                name: "FamilyMemberNeeds");

            migrationBuilder.DropTable(
                name: "FamilyNeeds");

            migrationBuilder.DropTable(
                name: "FamilyMemberNeedSubjects");

            migrationBuilder.DropTable(
                name: "FamilyMembers");

            migrationBuilder.DropTable(
                name: "FamilyNeedSubjects");

            migrationBuilder.DropTable(
                name: "Families");

            migrationBuilder.DropTable(
                name: "FamilyMemberRelations");

            migrationBuilder.DropTable(
                name: "Connectors");
        }
    }
}
