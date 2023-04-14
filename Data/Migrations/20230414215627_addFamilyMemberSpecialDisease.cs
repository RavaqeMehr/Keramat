using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class addFamilyMemberSpecialDisease : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "FamilyMembers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaritalStatus",
                table: "FamilyMembers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NationalCode",
                table: "FamilyMembers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FamilyMemberSpecialDiseaseSubjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyMemberSpecialDiseaseSubjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FamilyMemberSpecialDiseases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Order = table.Column<int>(type: "INTEGER", nullable: false),
                    FamilyMemberSpecialDiseaseSubjectId = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    FamilyMemberId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyMemberSpecialDiseases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FamilyMemberSpecialDiseases_FamilyMemberSpecialDiseaseSubjects_FamilyMemberSpecialDiseaseSubjectId",
                        column: x => x.FamilyMemberSpecialDiseaseSubjectId,
                        principalTable: "FamilyMemberSpecialDiseaseSubjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FamilyMemberSpecialDiseases_FamilyMembers_FamilyMemberId",
                        column: x => x.FamilyMemberId,
                        principalTable: "FamilyMembers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMemberSpecialDiseases_FamilyMemberId",
                table: "FamilyMemberSpecialDiseases",
                column: "FamilyMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMemberSpecialDiseases_FamilyMemberSpecialDiseaseSubjectId",
                table: "FamilyMemberSpecialDiseases",
                column: "FamilyMemberSpecialDiseaseSubjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FamilyMemberSpecialDiseases");

            migrationBuilder.DropTable(
                name: "FamilyMemberSpecialDiseaseSubjects");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "FamilyMembers");

            migrationBuilder.DropColumn(
                name: "MaritalStatus",
                table: "FamilyMembers");

            migrationBuilder.DropColumn(
                name: "NationalCode",
                table: "FamilyMembers");
        }
    }
}
