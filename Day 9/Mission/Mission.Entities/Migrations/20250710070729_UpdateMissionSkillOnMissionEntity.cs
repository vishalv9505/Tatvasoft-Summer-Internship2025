using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mission.Entities.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMissionSkillOnMissionEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MissionSkillId",
                table: "Missions",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_Missions_CityId",
                table: "Missions",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Missions_CountryId",
                table: "Missions",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Missions_Cities_CityId",
                table: "Missions",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Missions_Countries_CountryId",
                table: "Missions",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Missions_Cities_CityId",
                table: "Missions");

            migrationBuilder.DropForeignKey(
                name: "FK_Missions_Countries_CountryId",
                table: "Missions");

            migrationBuilder.DropIndex(
                name: "IX_Missions_CityId",
                table: "Missions");

            migrationBuilder.DropIndex(
                name: "IX_Missions_CountryId",
                table: "Missions");

            migrationBuilder.AlterColumn<int>(
                name: "MissionSkillId",
                table: "Missions",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
