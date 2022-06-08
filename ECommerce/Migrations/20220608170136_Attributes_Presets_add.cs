using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Migrations
{
    public partial class Attributes_Presets_add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Preset_Attribute_Attributes_AttributeId",
                table: "Preset_Attribute");

            migrationBuilder.DropForeignKey(
                name: "FK_Preset_Attribute_Presets_PresetId",
                table: "Preset_Attribute");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Preset_Attribute",
                table: "Preset_Attribute");

            migrationBuilder.RenameTable(
                name: "Preset_Attribute",
                newName: "Presets_Attributes");

            migrationBuilder.RenameIndex(
                name: "IX_Preset_Attribute_PresetId",
                table: "Presets_Attributes",
                newName: "IX_Presets_Attributes_PresetId");

            migrationBuilder.RenameIndex(
                name: "IX_Preset_Attribute_AttributeId",
                table: "Presets_Attributes",
                newName: "IX_Presets_Attributes_AttributeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Presets_Attributes",
                table: "Presets_Attributes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Presets_Attributes_Attributes_AttributeId",
                table: "Presets_Attributes",
                column: "AttributeId",
                principalTable: "Attributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Presets_Attributes_Presets_PresetId",
                table: "Presets_Attributes",
                column: "PresetId",
                principalTable: "Presets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Presets_Attributes_Attributes_AttributeId",
                table: "Presets_Attributes");

            migrationBuilder.DropForeignKey(
                name: "FK_Presets_Attributes_Presets_PresetId",
                table: "Presets_Attributes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Presets_Attributes",
                table: "Presets_Attributes");

            migrationBuilder.RenameTable(
                name: "Presets_Attributes",
                newName: "Preset_Attribute");

            migrationBuilder.RenameIndex(
                name: "IX_Presets_Attributes_PresetId",
                table: "Preset_Attribute",
                newName: "IX_Preset_Attribute_PresetId");

            migrationBuilder.RenameIndex(
                name: "IX_Presets_Attributes_AttributeId",
                table: "Preset_Attribute",
                newName: "IX_Preset_Attribute_AttributeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Preset_Attribute",
                table: "Preset_Attribute",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Preset_Attribute_Attributes_AttributeId",
                table: "Preset_Attribute",
                column: "AttributeId",
                principalTable: "Attributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Preset_Attribute_Presets_PresetId",
                table: "Preset_Attribute",
                column: "PresetId",
                principalTable: "Presets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
