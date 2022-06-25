using Microsoft.EntityFrameworkCore.Migrations;

namespace CVFilter.Infrastructure.Migrations
{
    public partial class RelationsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User",
                table: "Applicants");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Applicants",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Applicants",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Applicants",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ApplicantEducationRelation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantId = table.Column<int>(nullable: false),
                    SchoolName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantEducationRelation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicantEducationRelation_Applicants_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicantLanguageRelation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantId = table.Column<int>(nullable: false),
                    Langugage = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantLanguageRelation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicantLanguageRelation_Applicants_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantEducationRelation_ApplicantId",
                table: "ApplicantEducationRelation",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantLanguageRelation_ApplicantId",
                table: "ApplicantLanguageRelation",
                column: "ApplicantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicantEducationRelation");

            migrationBuilder.DropTable(
                name: "ApplicantLanguageRelation");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Applicants");

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "Applicants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
