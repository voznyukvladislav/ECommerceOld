using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Migrations
{
    public partial class Attributes_Presets_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attributes_Presets_PresetId",
                table: "Attributes");

            migrationBuilder.DropIndex(
                name: "IX_Attributes_PresetId",
                table: "Attributes");

            migrationBuilder.DropColumn(
                name: "PresetId",
                table: "Attributes");

            migrationBuilder.CreateTable(
                name: "Preset_Attribute",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttributeId = table.Column<int>(type: "int", nullable: false),
                    PresetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preset_Attribute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Preset_Attribute_Attributes_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "Attributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Preset_Attribute_Presets_PresetId",
                        column: x => x.PresetId,
                        principalTable: "Presets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Preset_Attribute_AttributeId",
                table: "Preset_Attribute",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_Preset_Attribute_PresetId",
                table: "Preset_Attribute",
                column: "PresetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Preset_Attribute");

            migrationBuilder.AddColumn<int>(
                name: "PresetId",
                table: "Attributes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attributes_PresetId",
                table: "Attributes",
                column: "PresetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attributes_Presets_PresetId",
                table: "Attributes",
                column: "PresetId",
                principalTable: "Presets",
                principalColumn: "Id");
        }
    }
}
