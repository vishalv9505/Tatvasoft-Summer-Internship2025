using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mission.Entities.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMissionEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Missions_MissionThemeId",
                table: "Missions",
                column: "MissionThemeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Missions_MissionThemes_MissionThemeId",
                table: "Missions",
                column: "MissionThemeId",
                principalTable: "MissionThemes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Missions_MissionThemes_MissionThemeId",
                table: "Missions");

            migrationBuilder.DropIndex(
                name: "IX_Missions_MissionThemeId",
                table: "Missions");
        }
    }
}
