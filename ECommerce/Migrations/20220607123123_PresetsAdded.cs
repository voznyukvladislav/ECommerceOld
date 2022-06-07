using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Migrations
{
    public partial class PresetsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PresetId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PresetId",
                table: "Attributes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Preset",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preset", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_PresetId",
                table: "Products",
                column: "PresetId");

            migrationBuilder.CreateIndex(
                name: "IX_Attributes_PresetId",
                table: "Attributes",
                column: "PresetId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attributes_Preset_PresetId",
                table: "Attributes");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Preset_PresetId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Preset");

            migrationBuilder.DropIndex(
                name: "IX_Products_PresetId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Attributes_PresetId",
                table: "Attributes");

            migrationBuilder.DropColumn(
                name: "PresetId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PresetId",
                table: "Attributes");
        }
    }
}
