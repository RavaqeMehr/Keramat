using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class addRefrencePropToNotRefrencedEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FamilyMemberNeeds_FamilyMembers_FamilyMemberId",
                table: "FamilyMemberNeeds");

            migrationBuilder.DropForeignKey(
                name: "FK_FamilyMemberSpecialDiseases_FamilyMembers_FamilyMemberId",
                table: "FamilyMemberSpecialDiseases");

            migrationBuilder.DropForeignKey(
                name: "FK_FamilyNeeds_Families_FamilyId",
                table: "FamilyNeeds");

            migrationBuilder.AlterColumn<int>(
                name: "FamilyId",
                table: "FamilyNeeds",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FamilyMemberId",
                table: "FamilyMemberSpecialDiseases",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FamilyId",
                table: "FamilyMemberSpecialDiseases",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "FamilyMemberId",
                table: "FamilyMemberNeeds",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FamilyId",
                table: "FamilyMemberNeeds",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMemberSpecialDiseases_FamilyId",
                table: "FamilyMemberSpecialDiseases",
                column: "FamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMemberNeeds_FamilyId",
                table: "FamilyMemberNeeds",
                column: "FamilyId");

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyMemberNeeds_Families_FamilyId",
                table: "FamilyMemberNeeds",
                column: "FamilyId",
                principalTable: "Families",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyMemberNeeds_FamilyMembers_FamilyMemberId",
                table: "FamilyMemberNeeds",
                column: "FamilyMemberId",
                principalTable: "FamilyMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyMemberSpecialDiseases_Families_FamilyId",
                table: "FamilyMemberSpecialDiseases",
                column: "FamilyId",
                principalTable: "Families",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyMemberSpecialDiseases_FamilyMembers_FamilyMemberId",
                table: "FamilyMemberSpecialDiseases",
                column: "FamilyMemberId",
                principalTable: "FamilyMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyNeeds_Families_FamilyId",
                table: "FamilyNeeds",
                column: "FamilyId",
                principalTable: "Families",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FamilyMemberNeeds_Families_FamilyId",
                table: "FamilyMemberNeeds");

            migrationBuilder.DropForeignKey(
                name: "FK_FamilyMemberNeeds_FamilyMembers_FamilyMemberId",
                table: "FamilyMemberNeeds");

            migrationBuilder.DropForeignKey(
                name: "FK_FamilyMemberSpecialDiseases_Families_FamilyId",
                table: "FamilyMemberSpecialDiseases");

            migrationBuilder.DropForeignKey(
                name: "FK_FamilyMemberSpecialDiseases_FamilyMembers_FamilyMemberId",
                table: "FamilyMemberSpecialDiseases");

            migrationBuilder.DropForeignKey(
                name: "FK_FamilyNeeds_Families_FamilyId",
                table: "FamilyNeeds");

            migrationBuilder.DropIndex(
                name: "IX_FamilyMemberSpecialDiseases_FamilyId",
                table: "FamilyMemberSpecialDiseases");

            migrationBuilder.DropIndex(
                name: "IX_FamilyMemberNeeds_FamilyId",
                table: "FamilyMemberNeeds");

            migrationBuilder.DropColumn(
                name: "FamilyId",
                table: "FamilyMemberSpecialDiseases");

            migrationBuilder.DropColumn(
                name: "FamilyId",
                table: "FamilyMemberNeeds");

            migrationBuilder.AlterColumn<int>(
                name: "FamilyId",
                table: "FamilyNeeds",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "FamilyMemberId",
                table: "FamilyMemberSpecialDiseases",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "FamilyMemberId",
                table: "FamilyMemberNeeds",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyMemberNeeds_FamilyMembers_FamilyMemberId",
                table: "FamilyMemberNeeds",
                column: "FamilyMemberId",
                principalTable: "FamilyMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyMemberSpecialDiseases_FamilyMembers_FamilyMemberId",
                table: "FamilyMemberSpecialDiseases",
                column: "FamilyMemberId",
                principalTable: "FamilyMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyNeeds_Families_FamilyId",
                table: "FamilyNeeds",
                column: "FamilyId",
                principalTable: "Families",
                principalColumn: "Id");
        }
    }
}
