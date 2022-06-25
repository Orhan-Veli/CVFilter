using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CVFilter.Infrastructure.Migrations
{
    public partial class LogsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantEducationRelation_Applicants_ApplicantId",
                table: "ApplicantEducationRelation");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantLanguageRelation_Applicants_ApplicantId",
                table: "ApplicantLanguageRelation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicantLanguageRelation",
                table: "ApplicantLanguageRelation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicantEducationRelation",
                table: "ApplicantEducationRelation");

            migrationBuilder.RenameTable(
                name: "ApplicantLanguageRelation",
                newName: "ApplicantLanguageRelations");

            migrationBuilder.RenameTable(
                name: "ApplicantEducationRelation",
                newName: "ApplicantEducationRelations");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicantLanguageRelation_ApplicantId",
                table: "ApplicantLanguageRelations",
                newName: "IX_ApplicantLanguageRelations_ApplicantId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicantEducationRelation_ApplicantId",
                table: "ApplicantEducationRelations",
                newName: "IX_ApplicantEducationRelations_ApplicantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicantLanguageRelations",
                table: "ApplicantLanguageRelations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicantEducationRelations",
                table: "ApplicantEducationRelations",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    ErrorMessage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantEducationRelations_Applicants_ApplicantId",
                table: "ApplicantEducationRelations",
                column: "ApplicantId",
                principalTable: "Applicants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantLanguageRelations_Applicants_ApplicantId",
                table: "ApplicantLanguageRelations",
                column: "ApplicantId",
                principalTable: "Applicants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantEducationRelations_Applicants_ApplicantId",
                table: "ApplicantEducationRelations");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantLanguageRelations_Applicants_ApplicantId",
                table: "ApplicantLanguageRelations");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicantLanguageRelations",
                table: "ApplicantLanguageRelations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicantEducationRelations",
                table: "ApplicantEducationRelations");

            migrationBuilder.RenameTable(
                name: "ApplicantLanguageRelations",
                newName: "ApplicantLanguageRelation");

            migrationBuilder.RenameTable(
                name: "ApplicantEducationRelations",
                newName: "ApplicantEducationRelation");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicantLanguageRelations_ApplicantId",
                table: "ApplicantLanguageRelation",
                newName: "IX_ApplicantLanguageRelation_ApplicantId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicantEducationRelations_ApplicantId",
                table: "ApplicantEducationRelation",
                newName: "IX_ApplicantEducationRelation_ApplicantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicantLanguageRelation",
                table: "ApplicantLanguageRelation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicantEducationRelation",
                table: "ApplicantEducationRelation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantEducationRelation_Applicants_ApplicantId",
                table: "ApplicantEducationRelation",
                column: "ApplicantId",
                principalTable: "Applicants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantLanguageRelation_Applicants_ApplicantId",
                table: "ApplicantLanguageRelation",
                column: "ApplicantId",
                principalTable: "Applicants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
