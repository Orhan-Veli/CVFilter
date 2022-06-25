using Microsoft.EntityFrameworkCore.Migrations;

namespace CVFilter.Infrastructure.Migrations
{
    public partial class ExperienceAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalExperience",
                table: "Applicants",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalExperience",
                table: "Applicants");
        }
    }
}
