using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoGamesCompaniesAPI.Migrations
{
    public partial class GameCompanyUserIdAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "GameCompanies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GameCompanies_CreatedById",
                table: "GameCompanies",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_GameCompanies_Users_CreatedById",
                table: "GameCompanies",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameCompanies_Users_CreatedById",
                table: "GameCompanies");

            migrationBuilder.DropIndex(
                name: "IX_GameCompanies_CreatedById",
                table: "GameCompanies");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "GameCompanies");
        }
    }
}
