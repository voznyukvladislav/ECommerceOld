using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Migrations
{
    public partial class PresetsAdded2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attributes_Preset_PresetId",
                table: "Attributes");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Preset_PresetId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Preset",
                table: "Preset");

            migrationBuilder.RenameTable(
                name: "Preset",
                newName: "Presets");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Presets",
                table: "Presets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Attributes_Presets_PresetId",
                table: "Attributes",
                column: "PresetId",
                principalTable: "Presets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Presets_PresetId",
                table: "Products",
                column: "PresetId",
                principalTable: "Presets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attributes_Presets_PresetId",
                table: "Attributes");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Presets_PresetId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Presets",
                table: "Presets");

            migrationBuilder.RenameTable(
                name: "Presets",
                newName: "Preset");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Preset",
                table: "Preset",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Attributes_Preset_PresetId",
                table: "Attributes",
                column: "PresetId",
                principalTable: "Preset",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Preset_PresetId",
                table: "Products",
                column: "PresetId",
                principalTable: "Preset",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
